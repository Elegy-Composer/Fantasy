using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MapObject.Interactable;

public class DialogTrigger : Interactable
{
    public Dialog dialogContent;
    public int index = 0;
    public bool InteractStarted = false;
    public override void Interact()//start conversation
    {
        if(index != 0)
        {
            Debug.Log("CLEAR TEXT");
            GameObject.Find("DialogManager").GetComponent<DialogManager>().ClearText();
        }
        else
        {
            GameObject.Find("DialogManager").GetComponent<DialogManager>().OpenWindow();
        }

        if (index == dialogContent.sentences.Length)//end conversation
        {
            index = 0;
            InteractStarted = false;
            GameObject.Find("DialogManager").GetComponent<DialogManager>().CloseWindow();
            return;
        }
        InteractStarted = true;
        Debug.Log("INDEX=" + index.ToString());
        GameObject.Find("DialogManager").GetComponent<DialogManager>().DisplayText(dialogContent.sentences[index]);
        index++;
    }





}
