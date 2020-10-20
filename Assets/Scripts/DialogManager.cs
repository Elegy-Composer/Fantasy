using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogManager : MonoBehaviour
{
    public TextMeshProUGUI dialogText;
    public Image dialogWindow;

    public float typeSpeed;
    private Coroutine lastSentence = null;

    public void DisplayText(string sentence)
    {
        if (lastSentence != null)
        {
            StopCoroutine(lastSentence);
        }
        lastSentence = StartCoroutine(TypeText(sentence));
    }

    IEnumerator TypeText(string sentence)
    {
        foreach (char c in sentence)
        {
            dialogText.text += c;
            yield return new WaitForSeconds(1 / typeSpeed);
        }

    }

    public void ClearText()
    {
        dialogText.text = "";
    }

    public void OpenWindow()
    {
        dialogWindow.color = new Color32(0, 0, 0, 185);
    }

    public void CloseWindow()
    {
        dialogWindow.color = new Color32(0, 0, 0, 0);
        if (lastSentence != null)
        {
            StopCoroutine(lastSentence);
            lastSentence = null;
        }
    }

}
