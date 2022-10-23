using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string ItemName;
    public Sprite sprite;
    public int count;

    public Inventory Inventory;



    public Item(string itemName, Sprite sprite)
    {
        this.sprite = sprite;
        this.ItemName = itemName;
    }
    public Item()
    {
        
    }
    private void OnEnable()
    {
        Inventory = FindObjectOfType<Inventory>();
    }
    private void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0) && Inventory.onMasa && gameObject.tag == "Item")
        {
            if (Inventory.index <= 4)
            {
                Inventory.AddItem(this);
                count--;
            }
            else
                Debug.Log("Envanter Dolu ama itemden");
        }
    }
}
