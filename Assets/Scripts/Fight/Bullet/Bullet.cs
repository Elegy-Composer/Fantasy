using UnityEngine;
using LivingThing;

namespace Fight.Bullet
{
    public class Bullet : MonoBehaviour
    {
        public Vector2 velocity;
        public LivingThing.LivingThing sender;

        public Bullet(LivingThing.LivingThing sender, Vector2 velocity)
        {
            this.velocity = velocity;
            this.sender = sender;
        }

        // Update is called once per frame
        private void Update()
        {
            transform.position += (Vector3) velocity * Time.deltaTime;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.name == "protagonist")
            {
                Debug.Log("Collided with the protagonist.");
            }
        }
    }
}