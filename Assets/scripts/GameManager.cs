using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    [SerializeField]
    GameObject[] switches;
    [SerializeField]
    GameObject exitDoor;
    [SerializeField]
    GameObject entryDoor;

    int noOfSwitches = 0;

    void Start()
    {
        GetNoOfSwitches();
    }

    private void GetNoOfSwitches()
    {
        int x = 0;
        for(int i =0; i < switches.Length; i++)
        {
            if(switches[i].GetComponent<Switch>().isOn == false)
            {
                x++;
            }else if (switches[i].GetComponent<Switch>().isOn == true)
            {
                noOfSwitches--;
            }
        }
        noOfSwitches = x;
    }

    public void SetExitDoorState()
    {
        if(noOfSwitches <= 0)
        {
            exitDoor.GetComponent<Door>().OpenDoor();
            entryDoor.GetComponent<Door>().OpenDoor();
        }
    }

    void Update()
    {
        GetNoOfSwitches();
        SetExitDoorState();
    }
}
