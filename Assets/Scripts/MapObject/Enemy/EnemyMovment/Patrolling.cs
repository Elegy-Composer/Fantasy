using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MapObject.Enemy;

namespace MapObject.Enemy
{
    public class Patrolling : EnemyMovement
    {

        #region Search-Range Variable

        public Vector2 origin;

        [SerializeField]
        private float halfSearchWidth;
        [SerializeField]
        private float halfSearchHeight;
        
        private int c_step;//current step
        private int g_step;//goal step

        #endregion

        private void Start()
        {
            origin = rb.position;
            ChangeDirection();
        }

        private void Update()
        {
            float x = transform.position.x;
            float y = transform.position.y;
            anim.SetFloat("speed", movement.sqrMagnitude);
            //if go outside the search range
            if (x <= origin.x - halfSearchWidth || x >= origin.x + halfSearchWidth || y <= origin.y - halfSearchHeight || y >= origin.y + halfSearchHeight)
            {
                movement *= -1;//go back
            }
        }

        private void FixedUpdate()
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }

        public void CheckStep()
        {
            c_step += 1;
            if (c_step == g_step)
            {
                ChangeDirection();//has moved required steps
            }
            else
            {
                return;
            }
        }

        public void ChangeDirection()
        {
            movement = new Vector2(0, 0);
            int stopChance = Random.Range(1, 5);
            if (stopChance == 1)
            {
                StartCoroutine(Stop());
            }
            else
            {
                int dir = SetDirection();
                Debug.Log(dir);
                g_step = Random.Range(2, 4);
                c_step = 0;
                switch (dir)
                {
                    case 0:
                        movement = new Vector2(1, 0);
                        break;
                    case 1:
                        movement = new Vector2(-1, 0);
                        break;
                    case 2:
                        movement = new Vector2(0, 1);
                        break;
                    case 3:
                        movement = new Vector2(0, -1);
                        break;
                }
            }
        }

        IEnumerator Stop()
        {
            float seconds = Random.Range(0.7f, 1.5f);
            yield return new WaitForSeconds(seconds);
            ChangeDirection();
        }
        
        public int SetDirection()//movment will tend to go back to the center
        {
            float right = (Mathf.Abs(transform.position.x - origin.x - halfSearchWidth) / (halfSearchWidth * 2));
            float left = (1 - right);
            float up = (Mathf.Abs(transform.position.y - origin.y - halfSearchHeight) / (halfSearchHeight * 2));
            float down = (1 - up);

            float total = right + left + up + down;
            Debug.Log(right);
            Debug.Log(total);
            int r = (int)(right / total * 100);
            int l = (int)(left / total * 100);
            int u = (int)(up / total * 100);
            int d = (int)(down / total * 100);

            Debug.Log(r);
            Debug.Log(l);
            Debug.Log(u);
            Debug.Log(d);
            int n = Random.Range(1, 101);

            if (n <= r)
            {
                return 0;
            }
            else if (n > r && n <= r + l)
            {
                return 1;
            }
            else if (n > r + l && n <= r + l + u)
            {
                return 2;
            }
            else if (n > r + l + u && n <= r + l + u + d)
            {
                return 3;
            }
            else
            {
                return Random.Range(0, 4);
            }
        }
    }
}