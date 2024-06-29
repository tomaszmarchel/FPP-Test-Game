using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableObjectSlotBase : MonoBehaviour, IMoveableObjectParent
{
    public MoveableObject moveableObjectInSlot;
    public Transform spawnPoint;
    public MoveableObjectsTypes.Type slotType;

    //INTERFACE IMPLEMENTATION
    #region INTERFACE
    public virtual Transform GetSpawnPoint()
    {
        return spawnPoint;
    }

    public virtual void SetMoveableObject(MoveableObject moveableObject)
    {
        this.moveableObjectInSlot = moveableObject;
    }

    public virtual MoveableObject GetMoveableObject()
    {
        return moveableObjectInSlot;
    }

    public virtual void ClearMoveableObject()
    {
        moveableObjectInSlot = null;
    }

    public virtual bool HasSelectedMoveableObject()
    {
        return moveableObjectInSlot != null;
    }

    public virtual MoveableObjectsTypes.Type GetParentType()
    {
        return slotType;
    }
    #endregion
}
