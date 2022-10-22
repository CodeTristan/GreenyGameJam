using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<Item> inventory = new List<Item>();

    public Image[] inventoryImages;
    public int index = 0;
    public bool onMasa = false;

    private bool onObject = false;
    private Item tempItem;
    private GameObject tempObject;

    public void AddItem(Item item)
    {
        RefleshInventoryUI();
        inventoryImages[index].gameObject.SetActive(true);
        inventoryImages[index].sprite = item.sprite;
        inventoryImages[index].gameObject.name = item.ItemName;
        index++;
        inventory.Add(item);
        if(item != null && item.count <= 0)
            item.gameObject.SetActive(false);
        tempItem = null;
        tempObject = null;
        Debug.Log("envanter : " + inventory.Count);
        
    }

    public void RefleshInventoryUI()
    {
        index = 0;
        for (int i = 0; i < inventoryImages.Length; i++)
        {
            inventoryImages[i].gameObject.SetActive(false);
        }
        int j = 0;
        foreach(Item item in inventory)
        {
            index++;
            inventoryImages[j].gameObject.SetActive(true);
            inventoryImages[j].sprite = item.sprite;
            inventoryImages[j].gameObject.name = item.ItemName;
            j++;
        }
    }
    public void DeleteItem(int index)
    {
        inventory.RemoveAt(index);
        index--;
        RefleshInventoryUI();
    }
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.tag == "Item")
        {
            tempItem = gameObject.AddComponent<Item>();
            onObject = true;
            tempItem = collider2D.gameObject.GetComponent<Item>();
            tempObject = collider2D.gameObject;
            
        }
    }

    private void OnTriggerExit2D(Collider2D collider2D)
    {
        if (collider2D.tag == "Item")
        {
            onObject = false;
            tempItem = null;
            tempObject = null;
        }
            
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && onObject)
        {
            if(index > 4)
            {
                Debug.Log("Envanter dolu");
            }
            else
            {
                AddItem(tempItem);
            }
            
        }
    }
}
