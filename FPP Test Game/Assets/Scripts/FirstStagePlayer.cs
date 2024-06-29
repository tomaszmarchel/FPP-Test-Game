using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstStagePlayer : MonoBehaviour, IMoveableObjectParent
{
    public static FirstStagePlayer Instance { get; private set; }
    
    private BaseInteractiveObject interactiveObject;
    private IMoveableObjectParent avatarSlot;
    
    private MoveableObject targetedMoveableObject;
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
            DropMoveableObject();
        }
    }

    private void DropMoveableObject()
    {
        if (avatarSlot != null)
        {
            if (avatarSlot.GetParentType() == holdingObject.GetMoveableObjectSO().itemType)
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
            {
                holdingObject.DestroySelf();
            }
        }
        else
        {
            holdingObject.DestroySelf();
        }
    }

    public void TargettingAtMoveableObject(Transform selectedItem)
    {
        if (selectedItem.TryGetComponent<MoveableObject>(out MoveableObject moveableObject))
        {
            MoveableItemAimedAt(moveableObject);
        }
        else
        {
            if (targetedMoveableObject != null)
            {
                //targetedMoveableObject.isPlayerTarget = false;
                targetedMoveableObject.MoveableObjectIsNotPlayerTarget();
                targetedMoveableObject = null;
            }
        }
    }

    private void WardrobeInteraction(Wardrobe selectedWardrobe)
    {
        interactiveObject = selectedWardrobe;
        interactiveObject.OnTarget();
    }

    private void MoveableItemAimedAt(MoveableObject moveableObject)
    {
        if (moveableObject == targetedMoveableObject || targetedMoveableObject == null)
        {
            targetedMoveableObject = moveableObject;
            targetedMoveableObject.MoveableObjectIsPlayerTarget();
            //targetedMoveableObject.isPlayerTarget = true;
        }
    }

    public void NotLookingOnAnyMoveableObject()
    {
        if (targetedMoveableObject != null)
        {
            targetedMoveableObject.MoveableObjectIsNotPlayerTarget();
            //targetedMoveableObject.isPlayerTarget = false;
            targetedMoveableObject = null;
        }
    }

    public void NotTargettingAnySlot()
    {
        if (avatarSlot != null)
        {
            avatarSlot = null;
        }
    }

    public void TargettingAtSlot(IMoveableObjectParent moveableObjectParent)
    {
        avatarSlot = moveableObjectParent;
    }

    public void TargettingAtWardrobe(Wardrobe wardrobe)
    {
        WardrobeInteraction(wardrobe);
    }

    // Interface implementation
    #region INTERFACE IMPLEMENTATION
    public Transform GetSpawnPoint()
    {
        return holdItemPoint;
    }

    public void SetMoveableObject(MoveableObject moveableObject)
    {
        this.holdingObject = moveableObject;
        LaserDetector.Instance.detectMoveableObjects = false;
    }

    public MoveableObject GetMoveableObject()
    {
        return holdingObject;
    }

    public void ClearMoveableObject()
    {
        holdingObject = null;
        LaserDetector.Instance.detectMoveableObjects = true;
    }

    public bool HasSelectedMoveableObject()
    {
        return holdingObject != null;
    }

    public MoveableObjectsTypes.Type GetParentType()
    {
        return holdingObject.GetMoveableObjectSO().itemType;
    }
    #endregion
}
