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
            Debug.Log(1);
            item.ItemName = itemName;
            item.sprite = sprite;
            FindObjectOfType<Inventory>().AddItem(item);
        }
        if(itemName == "Blue" && otherCrafting.itemName == "Yellow")
        {
            
            item.ItemName = "Yeþil";
            item.sprite = greenSprite;
            FindObjectOfType<Inventory>().AddItem(item);
        }
        else if (itemName == "Blue" && otherCrafting.itemName == "Red")
        {
            item.ItemName = "Mor";
            item.sprite = purpleSprite;
            FindObjectOfType<Inventory>().AddItem(item);
        }
        else if (itemName == "Red" && otherCrafting.itemName == "Yellow")
        {
            item.ItemName = "Turuncu";
            item.sprite = orangeSprite;
            FindObjectOfType<Inventory>().AddItem(item);
        }

        Debug.Log(2);
        itemName = "";
        sprite = null;
        otherCrafting.itemName = "";
        otherCrafting.sprite = null;
        gameObject.GetComponentInChildren<SpriteRenderer>().sprite = sprite;
        otherCrafting.gameObject.GetComponentInChildren<SpriteRenderer>().sprite = sprite;
    }
}
