using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{

    public bool room1Comp;
    public bool room1Alchemy;
    public bool room1Finished;
    public DialogueStarter room1finishDialog;
    private void Update()
    {
        if(room1Alchemy && room1Comp)
        {
            room1Comp = false;
            room1Alchemy = false;
            room1Finished = true;
            room1finishDialog.TriggerDialog();
        }
    }
}
