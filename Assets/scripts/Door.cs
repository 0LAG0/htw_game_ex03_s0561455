using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {
    Animator anim;
    [SerializeField]
    GameObject DoorType;

    int stateOfDoor = 1;

    [SerializeField]
    CharacterController player;

    void Start()
    {
        player = FindObjectOfType<CharacterController>();

        anim = GetComponent<Animator>();
        if (DoorType.name == "EntryDoor")
        {
            anim.SetFloat("DoorState", 1);
        }
        if (DoorType.name == "ExitDoor")
        {
            LockDoor();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(GetDoorState() == 3)
        {
            player.Teleport();
        }
        if (DoorType.name == "NextLvl")
        {
            player.NextLvl();
        }
    }

    public void LockDoor()
    {
        if(DoorType.name == "ExitDoor")
        {
            anim.SetFloat("DoorState", 1);
            stateOfDoor = 1;
        }
    }

    public void UnlockDoor()
    {
        if (DoorType.name == "ExitDoor")
        {
            anim.SetFloat("DoorState", 2);
            stateOfDoor = 2;
        }
    }

    public void OpenDoor()
    {
            anim.SetFloat("DoorState", 3);
            stateOfDoor = 3;
    }

    public int GetDoorState()
    {
        return stateOfDoor;
    }
}
