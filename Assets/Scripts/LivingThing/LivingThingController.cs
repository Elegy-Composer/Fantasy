using UnityEngine;

namespace LivingThing
{
    public class LivingThingController : MonoBehaviour
    {
        public Transform transform;
        public LivingThing controlled;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                transform.position += Vector3.up * controlled.speed;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                transform.position += Vector3.down * controlled.speed;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                transform.position += Vector3.left * controlled.speed;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                transform.position += Vector3.right * controlled.speed;
            }
        }
    }
}