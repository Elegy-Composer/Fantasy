using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using MapObject.Interactable;
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
                collision.gameObject.GetComponent<Interactable.Interactable>().ShowIcon();
                hint.GetComponent<Animator>().enabled = true;
                hint.GetComponent<TextMeshProUGUI>().text = "press z to open";
                interactObject = collision.gameObject;
            }
            if (collision.gameObject.tag == "npc")
            {
                Debug.Log("find a talkable object");
                collision.gameObject.GetComponent<Interactable.Interactable>().ShowIcon();
                hint.GetComponent<Animator>().enabled = true;
                hint.GetComponent<TextMeshProUGUI>().text = "press z to chat";
                interactObject = collision.gameObject;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "treasurebox") 
            {
                collision.gameObject.GetComponent<Interactable.Interactable>().HideIcon();
                hint.GetComponent<Animator>().enabled = false;
                hint.GetComponent<TextMeshProUGUI>().text = "";
                interactObject = null;
            }
            if (collision.gameObject.tag == "npc" && !collision.gameObject.GetComponent<DialogTrigger>().InteractStarted)
            {
                Debug.Log("EXIT_NPC");
                collision.gameObject.GetComponent<Interactable.Interactable>().HideIcon();
                hint.GetComponent<Animator>().enabled = false;
                hint.GetComponent<TextMeshProUGUI>().text = "";
                interactObject = null;
            }
        }
    }

    
}
