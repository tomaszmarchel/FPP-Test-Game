using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableWardobeSlot : MoveableObjectSlot
{
    void Start()
    {
        MoveableObject.SpawnArmoryObject(moveableObject.GetMoveableObjectSO(), this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
