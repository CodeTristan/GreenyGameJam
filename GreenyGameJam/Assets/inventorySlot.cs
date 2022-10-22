using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class inventorySlot : MonoBehaviour
{

    public DrawerPuzzle drawerPuzzle;
    public Crafting crafting;
    public Crafting crafting2;
    public PlayerMovement player;
    public int index;
    public void SendInfo()
    {
        if(player.DrawerOpened)
        {
            drawerPuzzle.pickedObject = gameObject.name;
            drawerPuzzle.index = index;
        }

        if(crafting.itemName == "")
        {
            crafting.sprite = gameObject.GetComponent<Image>().sprite;
            crafting.itemName = gameObject.name;
            crafting.index = index;
        }

        else if (crafting2.itemName == "")
        {
            crafting2.sprite = gameObject.GetComponent<Image>().sprite;
            crafting2.itemName = gameObject.name;
            crafting2.index = index;
        }
    }
}
