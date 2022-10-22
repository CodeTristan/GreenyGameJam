using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DrawerPuzzle : MonoBehaviour
{
    public TextMeshProUGUI ErrorText;
    public string pickedObject;

    public int length;

    public DrawerPuzzle drawerPuzzle;
    public int index;

    public int checkpoints = 0;
    public GameObject pcPasswordPaper;
    public GameObject pcPasswordPaperUI;
    public DialogueStarter afterDrawerDialog;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "DrawerButton")
        {
            Destroy(collision.collider.gameObject);
        }
    }

    private void Update()
    {
        if(checkpoints >= 3)
        {
            checkpoints = 0;
            afterDrawerDialog.TriggerDialog();
            pcPasswordPaper.SetActive(true);
            pcPasswordPaperUI.SetActive(true);
            FindObjectOfType<RoomManager>().room1Comp = true;
            drawerPuzzle.gameObject.SetActive(false);
        }
    }
    private void OnMouseDown()
    {
        
        pickedObject = drawerPuzzle.pickedObject;
        if(pickedObject == "short" && length == 1)
        {
            if (gameObject.name == "k�sa�st")
                drawerPuzzle.checkpoints++;
            gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
            drawerPuzzle.pickedObject = "";
            FindObjectOfType<Inventory>().DeleteItem(drawerPuzzle.index);
        }
        else if (pickedObject == "middle" && length == 2)
        {
            if (gameObject.name == "Sol" || gameObject.name == "Sa�")
                drawerPuzzle.checkpoints++;
            gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
            drawerPuzzle.pickedObject = "";
            FindObjectOfType<Inventory>().DeleteItem(drawerPuzzle.index);
        }
        else if (pickedObject == "long" && length == 3)
        {
            if (gameObject.name == "�st")
                drawerPuzzle.checkpoints++;
            gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
            drawerPuzzle.pickedObject = "";
            FindObjectOfType<Inventory>().DeleteItem(drawerPuzzle.index);
        }
        else
        {
            StopAllCoroutines();
            Debug.Log("Koymaya �al��t���n �ey �ok b�y�k");
            StartCoroutine(error());
        }
    }

    private IEnumerator error()
    {
        ErrorText.text = "Par�a uyu�muyor!!!";
        ErrorText.gameObject.SetActive(true);

        yield return new WaitForSeconds(2);

        ErrorText.gameObject.SetActive(false);
    }
}
