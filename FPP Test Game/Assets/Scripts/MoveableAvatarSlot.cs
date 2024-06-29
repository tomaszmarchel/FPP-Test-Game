using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableAvatarSlot : MoveableObjectSlotBase
{
    [SerializeField] private Transform visualTransparentBox;

    //INTERFACE IMPLEMENTATION
    #region INTERFACE IMPLEMENTATION
    public override Transform GetSpawnPoint()
    {
        return spawnPoint;
    }

    public override void SetMoveableObject(MoveableObject moveableObject)
    {
        this.moveableObjectInSlot = moveableObject;
        visualTransparentBox.gameObject.SetActive(false);
    }

    public override MoveableObject GetMoveableObject()
    {
        return moveableObjectInSlot;
    }

    public override void ClearMoveableObject()
    {
        moveableObjectInSlot = null;
        visualTransparentBox.gameObject.SetActive(true);
    }

    public override bool HasSelectedMoveableObject()
    {
        return moveableObjectInSlot != null;
    }

    public override MoveableObjectsTypes.Type GetParentType()
    {
        return slotType;
    }
    #endregion
}
