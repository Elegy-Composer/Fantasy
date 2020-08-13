using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fight;

namespace MapObject.PlayerController
{
    public class CollisionManager : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "enemy")
            {
                Debug.Log("encounter with an enemy");
            }
        }
    }
}
