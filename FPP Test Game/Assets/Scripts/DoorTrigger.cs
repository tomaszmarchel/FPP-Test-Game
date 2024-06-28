using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    private Door owner;

    public event EventHandler OnTriggerEnterEvent;
    public event EventHandler OnTriggerExitEvent;

    private void Awake()
    {
        owner = transform.parent.GetComponent<Door>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerAtTheDoor();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerOutsideTheDoor();
        }
    }

    private void OnDestroy()
    {
        PlayerOutsideTheDoor();
    }

    private void PlayerAtTheDoor()
    {
        UIManager.Instance.ShowInteractionText();
        Player.Instance.canInteract = true;
        Player.Instance.onInteractionDoor = owner;
    }

    private void PlayerOutsideTheDoor()
    {
        UIManager.Instance.HideInteractionText();
        Player.Instance.canInteract = false;
        Player.Instance.onInteractionDoor = null;
    }
}
