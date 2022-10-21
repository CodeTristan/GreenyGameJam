using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    List<string> inventory = new List<string>();

    private bool onObject = false;
    private string tempItem = "";
    private GameObject tempObject;
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.tag == "Item")
        {
            onObject = true;
            tempItem = collider2D.gameObject.name;
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            inventory.Add(tempItem);
            Destroy(tempObject);
            Debug.Log("envanter : " + inventory[0]);
        }
    }
}
