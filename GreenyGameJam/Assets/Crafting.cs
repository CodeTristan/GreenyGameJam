using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crafting : MonoBehaviour
{
    public string itemName;
    public Sprite sprite;
    public int index;

    public Crafting otherCrafting;

    public Sprite greenSprite;
    public Sprite purpleSprite;
    public Sprite orangeSprite;
    public Sprite finalFlashSprite;

    public bool[] crafted;
    public GameObject[] flasks;

    public Item item;
    private void OnMouseDown()
    {
        if(itemName != "")
        {
            item = new Item();
            gameObject.GetComponentInChildren<SpriteRenderer>().sprite = sprite;
            FindObjectOfType<Inventory>().DeleteItem(index);
        }
    }
    public void Craft()
    {
        if(itemName == otherCrafting.itemName)
        {
            item.ItemName = itemName;
            item.sprite = sprite;
            FindObjectOfType<Inventory>().AddItem(item);
        }
        if((itemName == "Blue" && otherCrafting.itemName == "Yellow") || (otherCrafting.itemName == "Blue" && itemName == "Yellow"))
        {
            
            item.ItemName = "Yeþil";
            item.sprite = greenSprite;
            FindObjectOfType<Inventory>().AddItem(item);
            crafted[0] = true;
            flasks[0].SetActive(true);
        }
        else if ((itemName == "Blue" && otherCrafting.itemName == "Red") || (otherCrafting.itemName == "Blue" && itemName == "Red"))
        {
            item.ItemName = "Mor";
            item.sprite = purpleSprite;
            FindObjectOfType<Inventory>().AddItem(item);
            crafted[1] = true;
            flasks[1].SetActive(true);
        }
        else if ((itemName == "Red" && otherCrafting.itemName == "Yellow") || (otherCrafting.itemName == "Red" && itemName == "Yellow"))
        {
            item.ItemName = "Turuncu";
            item.sprite = orangeSprite;
            FindObjectOfType<Inventory>().AddItem(item);
            crafted[2] = true;
            flasks[2].SetActive(true);
        }

        itemName = "";
        sprite = null;
        otherCrafting.itemName = "";
        otherCrafting.sprite = null;
        gameObject.GetComponentInChildren<SpriteRenderer>().sprite = sprite;
        otherCrafting.gameObject.GetComponentInChildren<SpriteRenderer>().sprite = sprite;

        if(crafted[0] && crafted[1] && crafted[2])
        {
            FindObjectOfType<Inventory>().inventory.Clear();
            FindObjectOfType<Inventory>().RefleshInventoryUI();
            item.ItemName = "FinalFlask";
            item.sprite = finalFlashSprite;
            FindObjectOfType<Inventory>().AddItem(item);
            FindObjectOfType<Inventory>().RefleshInventoryUI();
        }
    }
}
