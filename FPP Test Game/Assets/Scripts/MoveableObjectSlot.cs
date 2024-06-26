using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableObjectSlot : MonoBehaviour, IMoveableObjectParent
{
    [SerializeField] MoveableObject moveableObject;
    [SerializeField] Transform spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        MoveableObject.SpawnArmoryObject(moveableObject.GetMoveableObjectSO(), this);
    }

    // Update is called once per frame
    void Update()
    {

    }

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
