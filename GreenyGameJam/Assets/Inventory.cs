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
        inventoryImages[index].gameObject.SetActive(true);
        inventoryImages[index].sprite = item.sprite;
        inventoryImages[index].gameObject.name = item.ItemName;
        index++;
        inventory.Add(item);
        item.gameObject.SetActive(false);
        tempItem = null;
        tempObject = null;
        Debug.Log("envanter : " + inventory.Count);
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
