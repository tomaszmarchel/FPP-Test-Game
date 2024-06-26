using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IMoveableObjectParent
{
    public static Player Instance { get; private set; }
    
    private BaseInteractiveObject interactiveObject;
    private MoveableObject aimedMoveableObject;

    private MoveableObject holdingObject;
    [SerializeField] private Transform holdItemPoint;

    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (holdingObject != null)
        {
            if (!GameInput.Instance.isMouseButtonDown)
            {
                holdingObject.SetMoveableObjectParent(holdingObject.defaultParent);
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

    public void LookingOnNothing()
    {
        if (aimedMoveableObject != null)
        {
            aimedMoveableObject.isAimedOnMe = false;
            aimedMoveableObject = null;
        }
    }




    // interface

    public Transform GetSpawnPoint()
    {
        return holdItemPoint;
    }

    public void SetMoveableObject(MoveableObject moveableObject)
    {
        this.holdingObject = moveableObject;
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
}
