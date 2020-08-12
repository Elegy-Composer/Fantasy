using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fight.Model;

namespace MapObject.PlayerController
{
    public class CollisionManager : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)//set a trigger for non-physic collision
        {
            if (collision.gameObject.tag == "lord")
            {
                Debug.Log("encounter with a lord");
                SceneLoadingModel.LordName = collision.gameObject.name;
                SceneManager.LoadScene("FightScene");
            }
        }
    }

    
}
