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

    // Update is called once per frame
    void Update()
    {
        if (moveableObjectInSlot == null)
            MoveableObject.SpawnArmoryObject(originalMoveableObejct.GetMoveableObjectSO(), this);
    }

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
    }

    public override bool HasSelectedMoveableObject()
    {
        return moveableObjectInSlot != null;
    }
}
