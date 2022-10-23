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

    private void OnMouseDown()
    {
        SendInfo();
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
            Debug.Log(1);
            try
            {
                crafting.sprite = gameObject.GetComponent<Image>().sprite;
            }
            catch(NullReferenceException)
            {
                crafting.sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
            }
            crafting.itemName = gameObject.name;
            crafting.index = index;
        }

        else if (crafting2.itemName == "")
        {
            try
            {
                crafting.sprite = gameObject.GetComponent<Image>().sprite;
            }
            catch (NullReferenceException)
            {
                crafting.sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
            }
            crafting2.itemName = gameObject.name;
            crafting2.index = index;
        }
    }
}
