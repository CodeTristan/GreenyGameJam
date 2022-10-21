using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    List<Item> inventory = new List<Item>();
    
    
    

    private bool onObject = false;
    private Item tempItem;
    private GameObject tempObject;
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.tag == "Item")
        {
            onObject = true;
            tempItem = collider2D.gameObject.GetComponent<Item>();
            tempObject = collider2D.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collider2D)
    {
        if (collider2D.tag == "Item")
            onObject = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && onObject)
        {
            inventory.Add(tempItem);
            Destroy(tempObject);
            Debug.Log("envanter : " + inventory[0].ItemName);
        }
    }
}
