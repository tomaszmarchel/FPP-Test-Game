using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableObject : MonoBehaviour
{
    [SerializeField] MoveableObjectSO moveableObjectSO;

    private IMoveableObjectParent moveableObjectParent;
    public bool isAimedOnMe = false;


    private void Update()
    {
        
    }



    public MoveableObjectSO GetMoveableObjectSO()
    {
        return moveableObjectSO;
    }

    public void SetMoveableObjectParent(IMoveableObjectParent moveableObjectParent)
    {
        if (this.moveableObjectParent != null)
        {
            this.moveableObjectParent.ClearMoveableObject();
        }

        this.moveableObjectParent = moveableObjectParent;


        moveableObjectParent.SetMoveableObject(this);

        transform.parent = moveableObjectParent.GetSpawnPoint();

        transform.localPosition = Vector3.zero;

    }

    public void DestroySelf()
    {
        moveableObjectParent.ClearMoveableObject();

        Destroy(this.gameObject);
    }

    public static MoveableObject SpawnArmoryObject(MoveableObjectSO moveableObjectSO, IMoveableObjectParent moveableObjectParent)
    {
        Transform moveableObjectTransform = Instantiate(moveableObjectSO.prefab);
        MoveableObject moveableObject = moveableObjectTransform.GetComponent<MoveableObject>();
        moveableObject.SetMoveableObjectParent(moveableObjectParent);

        return moveableObject;
    }

    public void ShowOutline()
    {

    }

    public void HideOutline()
    {

    }
}
