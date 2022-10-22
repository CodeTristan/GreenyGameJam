using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventorySlot : MonoBehaviour
{

    public DrawerPuzzle drawerPuzzle;
    public int index;

    public void SendInfo()
    {
        drawerPuzzle.pickedObject = gameObject.name;
        drawerPuzzle.index = index;
    }
}
