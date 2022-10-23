using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;
    private Dialogue[] currentDialogs;

    public Animator animator;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogText;
    public Image picture;

    public float typeSpeed;
    public int dialogCount;
    public int maxDialogCount;
    public string context;
    public bool isThereChoice;

    public bool InDialogue;
    private bool canSkip;
    private bool yaziSkip;
    private string sentence;

    [Header("GameObjects")]
    public GameObject numPad;
    public GameObject pcPasswordPaper;
    public GameObject pcPasswordPaperUI;
    public GameObject Room2Cutscene;
    public GameObject Room2AynaMinigame;
    public GameObject room2Tel;
    public DialogueStarter room2CutsceneDialog;

    private void Start()
    {
        sentences = new Queue<string>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (canSkip && !yaziSkip)
                DisplayNextSentence();
            if (yaziSkip)
            {
                StopAllCoroutines();
                dialogText.text = sentence;
                canSkip = true;
                yaziSkip = false;
            }
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pcPasswordPaperUI.SetActive(false);
            Room2AynaMinigame.SetActive(false);
        }
    }

    public void StartDialog(Dialogue[] dialog, bool choice)
    {
        InDialogue = true;
        FindObjectOfType<PlayerMovement>().canmove = false;
        isThereChoice = choice;
        currentDialogs = dialog;
        animator.SetBool("isOpen", true);
        if (dialogCount == maxDialogCount)
        {
            EndDialog();
            return;
        }
        nameText.text = dialog[dialogCount].name;
        picture.sprite = dialog[dialogCount].sprite;
        
        sentences.Clear();

        foreach (string sentence in dialog[dialogCount].sentences.sentences)
        {
            sentences.Enqueue(sentence);
        }
        if (sentences.Count != 0)
            sentences.Dequeue();

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        canSkip = false;
        if (dialogCount == maxDialogCount)
        {
            EndDialog();
            return;
        }
        if (sentences.Count == 0)
        {
            dialogCount++;
            StartDialog(currentDialogs, isThereChoice);
        }
        else
        {
            sentence = sentences.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));
        }
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(typeSpeed);
            int random = Random.Range(0, 4);
            yaziSkip = true;
        }
        yaziSkip = false;
        canSkip = true;
    }

    public void EndDialog()
    {
        animator.SetBool("isOpen", false);
        isThereChoice = false;
        InDialogue = false;
        FindObjectOfType<PlayerMovement>().canmove = true;

        if (context == "pcDialog")
            numPad.SetActive(true);
        else if (context == "Drawer")
        {
            FindObjectOfType<PlayerMovement>().collider.enabled = true;
        }
        else if (context == "pcPasswordPaper")
            pcPasswordPaperUI.SetActive(true);
        else if (context == "afterCraft")
        {
            FindObjectOfType<Inventory>().inventory.Clear();
            FindObjectOfType<Inventory>().RefleshInventoryUI();
        }
        else if (context == "Room2Cutscene")
        {
            Room2Cutscene.SetActive(false);
        }
        else if (context == "Room2FirstTalk")
        {
            Room2Cutscene.SetActive(true);
            room2CutsceneDialog.TriggerDialog();
        }
        else if (context == "room2Ayna")
        {
            Room2AynaMinigame.SetActive(true);
        }
        else if (context == "Ajanda")
        {
            room2Tel.SetActive(true);
        }


    }

}
