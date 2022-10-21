using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    List<string> inventory = new List<string>();

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            inventory.Add(collider2D.gameObject.name);

        }
    }

    void Update()
    {
        if (inventory.Count > 0)
        {
            print("envanter : " + inventory[0]);

        }
    }
}
