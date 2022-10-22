using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class numPad : MonoBehaviour
{
    public TextMeshProUGUI text;
    public DialogueStarter afterPcDialog;
    public void ButtonClick()
    {
        if(text.text.Length < 5)
        {
            text.text += EventSystem.current.currentSelectedGameObject.name;
        }
        else
        {
            text.text = "";
        }

    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    public void Confirm()
    {
        if(text.text == "26950")
        {
            afterPcDialog.TriggerDialog();
        }
        else
        {
            text.text = "";
        }
    }
}
