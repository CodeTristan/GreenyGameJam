using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueStarter : MonoBehaviour
{
    public string Context;
    public bool isThereChoiceAfterwards;
    public Dialogue[] dialog;
    public bool dialogFinished = false;

    private DialogueManager manager;
    private GameObject choiceScreen;
    private bool playerTouched;
    private void Awake()
    {
        manager = FindObjectOfType<DialogueManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            playerTouched = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerTouched = false;
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && playerTouched && !manager.InDialogue)
            TriggerDialog();
    }
    public void TriggerDialog()
    {
        manager.maxDialogCount = dialog.Length;
        manager.dialogCount = 0;
        manager.StartDialog(dialog, isThereChoiceAfterwards);
        manager.context = Context;
    }

   
}
