using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MapObject.Movement;

namespace MapObject.Enemy
{
    public class Patrolling : MonoBehaviour
    {
        public MovementData move;

        #region Search-Range Variable

        public Vector2 origin;

        [SerializeField]
        private float halfSearchWidth;
        [SerializeField]
        private float halfSearchHeight;
        
        private int currentStep;//current step
        private int goalStep;//goal step

        #endregion

        #region Main Method

        private void Start()
        {
            origin = move.rb.position;
            ChangeDirection();
        }

        private void Update()
        {
            float x = transform.position.x;
            float y = transform.position.y;
            move.anim.SetFloat("speed", move.movement.sqrMagnitude);
            //if go outside the search range
            if (x <= origin.x - halfSearchWidth || x >= origin.x + halfSearchWidth || y <= origin.y - halfSearchHeight || y >= origin.y + halfSearchHeight)
            {
                move.movement *= -1;//go back
            }
        }

        private void FixedUpdate()
        {
            if (move.isFacingRight && move.movement.x < 0f || !move.isFacingRight && move.movement.x > 0f)//flip the character
            {
                float x = transform.localScale.x;
                float y = transform.localScale.y;
                float z = transform.localScale.z;
                x *= -1;
                transform.localScale = new Vector3(x, y, z);
                move.isFacingRight = !move.isFacingRight;
            }
            move.rb.MovePosition(move.rb.position + move.movement * move.moveSpeed * Time.fixedDeltaTime);
        }

        #endregion

        #region Decide Action Method

        public void CheckStep()
        {
            currentStep += 1;
            if (currentStep == goalStep)
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
            move.movement = new Vector2(0, 0);
            int stopChance = Random.Range(1, 5);
            if (stopChance == 1)
            {
                StartCoroutine(Stop());
            }
            else
            {
                int dir = SetDirection();
                Debug.Log(dir);
                goalStep = Random.Range(2, 4);
                currentStep = 0;
                switch (dir)
                {
                    case 0:
                        move.movement = new Vector2(1, 0);
                        break;
                    case 1:
                        move.movement = new Vector2(-1, 0);
                        break;
                    case 2:
                        move.movement = new Vector2(0, 1);
                        break;
                    case 3:
                        move.movement = new Vector2(0, -1);
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
            //float right = (Mathf.Abs(transform.position.x - origin.x - halfSearchWidth) / (halfSearchWidth * 2));
            float right = (Mathf.Abs(transform.position.x - origin.x - halfSearchWidth));
            float left = (halfSearchWidth * 2 - right);
            float up = (Mathf.Abs(transform.position.y - origin.y - halfSearchHeight));
            float down = (halfSearchHeight * 2 - up);

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
        #endregion
    }
}