using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableWardobeSlot : MoveableObjectSlotBase
{
    [SerializeField] MoveableObject originalMoveableObejct;
    void Start()
    {
        MoveableObject.SpawnArmoryObject(originalMoveableObejct.GetMoveableObjectSO(), this);
    }

    //INTERAFACE IMPLEMENTATION
    #region INTERFACE
    public override Transform GetSpawnPoint()
    {
        return spawnPoint;
    }

    public override void SetMoveableObject(MoveableObject moveableObject)
    {
        this.moveableObjectInSlot = moveableObject;
    }

    public override MoveableObject GetMoveableObject()
    {
        return moveableObjectInSlot;
    }

    public override void ClearMoveableObject()
    {
        moveableObjectInSlot = null;

        MoveableObject.SpawnArmoryObject(originalMoveableObejct.GetMoveableObjectSO(), this);
    }

    public override bool HasSelectedMoveableObject()
    {
        return moveableObjectInSlot != null;
    }
    #endregion
}
