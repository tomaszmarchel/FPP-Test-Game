using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IMoveableObjectParent
{
    public static Player Instance { get; private set; }
    
    private BaseInteractiveObject interactiveObject;
    private MoveableObject aimedMoveableObject;
    private IMoveableObjectParent avatarSlot;

    private MoveableObject holdingObject;
    [SerializeField] private Transform holdItemPoint;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        GameInput.Instance.OnMouseButtonUp += GameInput_OnMouseButtonUp;

    }

    private void GameInput_OnMouseButtonUp(object sender, EventArgs e)
    {
        if (holdingObject != null)
        {
            if (avatarSlot != null)
            {
                if (avatarSlot.GetSlotType() == holdingObject.GetMoveableObjectSO().itemType)
                {
                    if (avatarSlot.GetMoveableObject() == null)
                    {
                        holdingObject.SetMoveableObjectParent(avatarSlot);
                    }
                    else
                    {
                        holdingObject.DestroySelf();
                    }
                }
                else
                    holdingObject.DestroySelf();
            }
            else
            {
                holdingObject.DestroySelf();
            }
        }
    }

    public void SetSelectedItem(Transform selectedItem)
    {
        if (selectedItem.TryGetComponent<Wardrobe>(out Wardrobe selectedWardrobe))
        {
            WardrobeInteraction(selectedWardrobe);
        }

        if (selectedItem.TryGetComponent<MoveableObject>(out MoveableObject moveableObject))
        {
            MoveableItemAimedAt(moveableObject);
        }
        else
        {
            if (aimedMoveableObject != null)
            {

                aimedMoveableObject.isAimedOnMe = false;
                aimedMoveableObject = null;
            }
        }
    }

    private void WardrobeInteraction(Wardrobe selectedWardrobe)
    {
        interactiveObject = selectedWardrobe;
        interactiveObject.OnSelect();
    }

    private void MoveableItemAimedAt(MoveableObject moveableObject)
    {
        if (moveableObject == aimedMoveableObject || aimedMoveableObject == null)
        {
            aimedMoveableObject = moveableObject;
            aimedMoveableObject.isAimedOnMe = true;
        }
    }

    public void NotLookingOnAnyInteractiveObject()
    {
        if (aimedMoveableObject != null)
        {
            aimedMoveableObject.isAimedOnMe = false;
            aimedMoveableObject = null;
        }
    }

    public void NotLookingOnAnySlot()
    {
        if (avatarSlot != null)
        {
            avatarSlot = null;
        }
    }

    public void AimingOnSlot(IMoveableObjectParent moveableObjectParent)
    {
        avatarSlot = moveableObjectParent;
    }

    public void AimingOnWardrobe(Wardrobe wardrobe)
    {
        WardrobeInteraction(wardrobe);
    }

    public void AimingOnMoveableObject(MoveableObject moveableObject)
    {
        MoveableItemAimedAt(moveableObject);
    }


    // interface

    public Transform GetSpawnPoint()
    {
        return holdItemPoint;
    }

    public void SetMoveableObject(MoveableObject moveableObject)
    {
        this.holdingObject = moveableObject;
        LaserDetector.Instance.detectInteractiveObjects = false;
    }

    public MoveableObject GetMoveableObject()
    {
        return holdingObject;
    }

    public void ClearMoveableObject()
    {
        holdingObject = null;
    }

    public bool HasSelectedMoveableObject()
    {
        return holdingObject != null;
    }

    public MoveableObjectsTypes.Type GetSlotType()
    {
        return holdingObject.GetMoveableObjectSO().itemType;
    }
}
