using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Fight.Model;

namespace MapObject.PlayerController
{
    public class CollisionManager : MonoBehaviour
    {
        public static GameObject interactObject;

        private void OnTriggerEnter2D(Collider2D collision)//set a trigger for non-physic collision
        {
            if (collision.gameObject.tag == "lord")
            {
                Debug.Log("encounter with a lord");
                SceneLoadingModel.LordName = collision.gameObject.name;
                SceneManager.LoadScene("FightScene");
            }

            if (collision.gameObject.tag == "treasurebox")
            {
                Debug.Log("find a treasure box");
                Debug.Log(GameObject.Find("HintText"));
                TextMeshProUGUI hint = GameObject.Find("HintText").GetComponent<TextMeshProUGUI>();
                Debug.Log(hint);
                hint.text = "press z to open";
                interactObject = collision.gameObject;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "treasurebox") 
            {
                TextMeshProUGUI hint = GameObject.Find("HintText").GetComponent<TextMeshProUGUI>();
                hint.text = "";
                interactObject = null;
            }
        }
    }

    
}
