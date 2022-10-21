using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class DrawerPuzzle : MonoBehaviour
{
    public GameObject[] shortWay;
    public GameObject[] middleWay;
    public GameObject[] LongWay;

    public int index;
    public string pickedObject;

    private void Update()
    {
        if(EventSystem.current.currentSelectedGameObject.name == "short")
        {
            pickedObject = "short";
        }
        else if (EventSystem.current.currentSelectedGameObject.name == "medium")
        {
            pickedObject = "medium";
        }
        else if (EventSystem.current.currentSelectedGameObject.name == "long")
        {
            pickedObject = "long";
        }
    }
}
