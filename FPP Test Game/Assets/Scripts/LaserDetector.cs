using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LaserDetector : MonoBehaviour
{
    public static LaserDetector Instance { get; private set; }

    [SerializeField] Transform rayStartPoint;

    [SerializeField] LayerMask wardrobeLayerMask;
    [SerializeField] LayerMask moveableObjectlayerMask;
    [SerializeField] LayerMask slotlayerMask;

    public bool detectMoveableObjects = true;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (detectMoveableObjects)
            DetectMoveableObjects();

        DetectAvatarSlots();
        DetecWardrobesObjects();
    }

    private void DetecWardrobesObjects()
    {
        Physics.Raycast(rayStartPoint.position, rayStartPoint.forward, out RaycastHit hitInfo, 20f, wardrobeLayerMask);

        if (hitInfo.transform != null)
        {
            var hittedGameObject = hitInfo.transform;
            if (hittedGameObject.TryGetComponent<Wardrobe>(out Wardrobe wardrobe))
            {
                FirstStagePlayer.Instance.AimingOnWardrobe(wardrobe);
            }
        }
    }

    private void DetectMoveableObjects()
    {
        Physics.Raycast(rayStartPoint.position, rayStartPoint.forward, out RaycastHit hitInfo, 20f, moveableObjectlayerMask);

        if (hitInfo.transform != null)
        {
            var hittedGameObject = hitInfo.transform;
            FirstStagePlayer.Instance.AimedAtMoveableObject(hittedGameObject);
        }
        else
        {
            FirstStagePlayer.Instance.NotLookingOnAnyMoveableObject();
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
                FirstStagePlayer.Instance.AimingOnSlot(moveableAvatarSlot);
            }
        }
        else
        {
            FirstStagePlayer.Instance.NotLookingOnAnySlot();
        }
    }
}
