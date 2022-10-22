using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{

    public bool room1Comp;
    public bool room1Alchemy;
    public bool room1Finished;
    public DialogueStarter room1finishDialog;

    public GameObject room1;
    public GameObject room2;

    bool firstTimeinRoom2 = true;
    public DialogueStarter room2FirstDialog;

    public GameObject player;
    private void Update()
    {
        if (player.activeSelf == false)
            player.SetActive(true);
        if(room1Alchemy && room1Comp)
        {
            room1Comp = false;
            room1Alchemy = false;
            room1Finished = true;
            room1finishDialog.TriggerDialog();
        }
    }


    public void ChangeRoom()
    {
        if(room1.activeSelf)
        {
            room1.SetActive(false);
            room2.SetActive(true);
            if(firstTimeinRoom2)
            {
                firstTimeinRoom2 = false;
                room2FirstDialog.TriggerDialog();
            }
        }
        else
        {
            room1.SetActive(true);
            room2.SetActive(false);
        }
    }


}
