using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Fight;

namespace MapObject.PlayerController
{
    public class CollisionManager : MonoBehaviour
    {
        public static GameObject interactObject;
        public GameObject hint;

        private void OnTriggerEnter2D(Collider2D collision)//set a trigger for non-physic collision
        {
            if (collision.gameObject.tag == "lord")
            {
                Debug.Log("encounter with a lord");
                FightSceneLoader.LoadScene(collision.gameObject.name);
            }

            if (collision.gameObject.tag == "treasurebox")
            {
                Debug.Log("find a treasure box");
                hint.GetComponent<Animator>().enabled = true;
                hint.GetComponent<TextMeshProUGUI>().text = "press z to open";
                interactObject = collision.gameObject;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "treasurebox") 
            {
                hint.GetComponent<Animator>().enabled = false;
                hint.GetComponent<TextMeshProUGUI>().text = "";
                interactObject = null;
            }
        }
    }

    
}
