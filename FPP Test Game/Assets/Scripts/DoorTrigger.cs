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
            UIManager.Instance.ShowInteractionText();
            Player.Instance.canInteract = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            UIManager.Instance.HideInteractionText();
            Player.Instance.canInteract = true;
        }
    }

    private void OnDestroy()
    {
        // Needed because UI will not disapear
        UIManager.Instance.HideInteractionText();
    }
}
