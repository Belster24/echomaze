using System;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameManager gameManager;

    public enum DoorType
    {
        Start,
        End,
        Inside,
        EndLevel
    }

    public DoorType doorType;
    public List<Lock> locks;
    public bool isLocked;

    private void Start()
    {
        if (locks.Count > 0)
            isLocked = true;
    }
    

   

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (locks.Count <= 0)
            isLocked = false; //if no locks, unlock door, this is just a precaution, doors should be unlocked at lock

        if (other.CompareTag("Player") && !isLocked)
        {
            //if the door is unlocked and collides with player
            Debug.Log("is colliding with door");

            switch (doorType)
            {
                case DoorType.End:
                    gameManager.MoveToNextLevel();
                    break;
                case DoorType.Start:
                    Debug.Log("Start door");
                    break;
                case DoorType.Inside:
                    break;
                case DoorType.EndLevel:
                    gameManager.EndPassage();
                    break;
            }
        }
    }
}