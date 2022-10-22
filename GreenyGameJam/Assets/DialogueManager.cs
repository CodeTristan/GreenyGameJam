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

        foreach (string sentence in dialog[dialogCount].sentences)
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

    }

}
