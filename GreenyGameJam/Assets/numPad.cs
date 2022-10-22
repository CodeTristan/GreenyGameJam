using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class numPad : MonoBehaviour
{
    public TextMeshProUGUI text;
    public DialogueStarter afterPcDialog;
    public string password;
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Close();
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    public void Confirm()
    {
        if(text.text == password)
        {
            afterPcDialog.TriggerDialog();
            gameObject.SetActive(false);
        }
        else
        {
            text.text = "";
        }
    }
}
