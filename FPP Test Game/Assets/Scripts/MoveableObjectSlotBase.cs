using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableObjectSlotBase : MonoBehaviour, IMoveableObjectParent
{
    public MoveableObject moveableObjectInSlot;
    public Transform spawnPoint;

    public MoveableObjectsTypes.Type slotType;

    // Start is called before the first frame update


    //interface

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

    public virtual MoveableObjectsTypes.Type GetSlotType()
    {
        return slotType;
    }
}
