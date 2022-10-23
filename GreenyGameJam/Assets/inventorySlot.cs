using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class inventorySlot : MonoBehaviour
{

    public DrawerPuzzle drawerPuzzle;
    public Crafting crafting;
    public Crafting crafting2;
    public Crafting crafting3;
    public Crafting crafting4;
    public PlayerMovement player;
    public int index;

    public TextMeshProUGUI hoverText;
    private void OnMouseOver()
    {
        if (!hoverText.gameObject.activeSelf)
            hoverText.gameObject.SetActive(true);
        hoverText.transform.parent.position = gameObject.transform.position - new Vector3(0, 1, 0);
        hoverText.text = gameObject.name;
    }

    private void OnMouseExit()
    {
        hoverText.gameObject.SetActive(false);
    }


    public void SendInfo()
    {
        if(player.DrawerOpened)
        {
            drawerPuzzle.pickedObject = gameObject.name;
            drawerPuzzle.index = index;
        }

        if(crafting.itemName == "")
        {
            
            try
            {
                Debug.Log("try");
                crafting.sprite = gameObject.GetComponent<Image>().sprite;
            }
            catch(NullReferenceException)
            {
                Debug.Log("catch");
                crafting.sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
            }
            crafting.itemName = gameObject.name;
            crafting.index = index;
        }

        else if (crafting2.itemName == "")
        {
            try
            {
                crafting2.sprite = gameObject.GetComponent<Image>().sprite;
            }
            catch (NullReferenceException)
            {
                crafting2.sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
            }
            crafting2.itemName = gameObject.name;
            crafting2.index = index;
        }

        if (crafting3.itemName == "")
        {
            try
            {
                crafting3.sprite = gameObject.GetComponent<Image>().sprite;
            }
            catch (NullReferenceException)
            {
                crafting3.sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
            }
            crafting3.itemName = gameObject.name;
            crafting3.index = index;
        }
        else if (crafting4.itemName == "")
        {
            try
            {
                crafting4.sprite = gameObject.GetComponent<Image>().sprite;
            }
            catch (NullReferenceException)
            {
                crafting4.sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
            }
            crafting4.itemName = gameObject.name;
            crafting4.index = index;
        }
    }
}
