using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string ItemName;
    public Sprite sprite;

    private Inventory Inventory;

    private void Start()
    {
        Inventory = FindObjectOfType<Inventory>();
    }
    private void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0) && Inventory.onMasa)
        {
            if (Inventory.index <= 4)
                Inventory.AddItem(this);
            else
                Debug.Log("Envanter Dolu ama itemden");
        }
    }
}
