using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LaserDetector : MonoBehaviour
{
    public static LaserDetector Instance { get; private set; }

    [SerializeField] Transform rayStartPoint;
    [SerializeField] LayerMask interactiveObjectlayerMask;
    [SerializeField] LayerMask slotlayerMask;

    public bool detectInteractiveObjects = true;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (detectInteractiveObjects)
            DetectInteractiveObjects();

        DetectAvatarSlots();
    }

    private void DetectInteractiveObjects()
    {
        Physics.Raycast(rayStartPoint.position, rayStartPoint.forward, out RaycastHit hitInfo, 20f, interactiveObjectlayerMask);

        if (hitInfo.transform != null)
        {
            var hittedGameObject = hitInfo.transform;
            Player.Instance.SetSelectedItem(hittedGameObject);
        }
        else
        {
            Player.Instance.NotLookingOnAnyInteractiveObject();
        }
    }

    private void DetectAvatarSlots()
    {
        Physics.Raycast(rayStartPoint.position, rayStartPoint.forward, out RaycastHit hitInfo, 20f, slotlayerMask);

        if (hitInfo.transform != null)
        {
            var hittedSlot = hitInfo.transform;
            if (hittedSlot.TryGetComponent<MoveableAvatarSlot>(out MoveableAvatarSlot moveableAvatarSlot))
            {
                Player.Instance.AimingOnSlot(moveableAvatarSlot);
            }
        }
        else
        {
            Player.Instance.NotLookingOnAnySlot();
        }
    }
}
