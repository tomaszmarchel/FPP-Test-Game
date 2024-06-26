using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableObjectSlot : MonoBehaviour, IMoveableObjectParent
{
    protected MoveableObject moveableObject;
    protected Transform spawnPoint;

    public MoveableObjectsTypes.Type slotType;

    // Start is called before the first frame update


    //interface

    public Transform GetSpawnPoint()
    {
        return spawnPoint;
    }

    public void SetMoveableObject(MoveableObject moveableObject)
    {
        this.moveableObject = moveableObject;
    }

    public MoveableObject GetMoveableObject()
    {
        return moveableObject;
    }

    public void ClearMoveableObject()
    {
        moveableObject = null;
    }

    public bool HasSelectedMoveableObject()
    {
        return moveableObject != null;
    }
}
