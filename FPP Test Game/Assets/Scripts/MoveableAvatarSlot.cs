using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableAvatarSlot : MoveableObjectSlotBase
{
    [SerializeField] private Transform visualTransparentBox;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetMoveableObject() != null)
            visualTransparentBox.gameObject.SetActive(false);
        else
        {
            if (!visualTransparentBox.gameObject.activeSelf)
                visualTransparentBox.gameObject.SetActive(true);
        }
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

    public override MoveableObjectsTypes.Type GetSlotType()
    {
        return slotType;
    }
}
