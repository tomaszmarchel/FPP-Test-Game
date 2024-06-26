using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MoveableObject : MonoBehaviour
{
    [SerializeField] MoveableObjectSO moveableObjectSO;

    private IMoveableObjectParent moveableObjectParent;

    public bool isAimedOnMe = false;
    public bool selectedOnMe = false;

    [SerializeField] bool hasSkinnedMeshRenderer = false;
    [SerializeField] MeshRenderer meshRenderer;
    [SerializeField] SkinnedMeshRenderer skinnedMeshRenderer;

    [SerializeField] Material[] defaultMaterials;
    [SerializeField] Material[] outlineYellowMaterialArray;
    [SerializeField] Material[] outlineGreenMaterialArray;


    public enum OutlineState
    {
        None,
        Aimed,
        Seleceted
    }

    private OutlineState state;

    private void Start()
    {
        state = OutlineState.None;
    }


    private void Update()
    {
        if (isAimedOnMe)
        {
            if (GameInput.Instance.isMouseButtonDown)
            {
                state = OutlineState.Seleceted;
            }
            else
            {
                state = OutlineState.Aimed;
            }

            if (state == OutlineState.Seleceted)
            {
                SetMoveableObjectParent(Player.Instance);
            }

            ShowOutline();
        }
        else
        {
            HideOutline();
            
        }

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
        transform.eulerAngles = Vector3.zero;

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
        if (state == OutlineState.Aimed)
        {
            if (hasSkinnedMeshRenderer)
                skinnedMeshRenderer.SetMaterials(outlineYellowMaterialArray.ToList());
            else
                meshRenderer.SetMaterials(outlineYellowMaterialArray.ToList());

        }
        else if (state == OutlineState.Seleceted)
        {
            if (hasSkinnedMeshRenderer)
                skinnedMeshRenderer.SetMaterials(outlineGreenMaterialArray.ToList());
            else
                meshRenderer.SetMaterials(outlineGreenMaterialArray.ToList());
        }
    }

    public void HideOutline()
    {
        isAimedOnMe = false;
        state = OutlineState.None;

        if (hasSkinnedMeshRenderer)
            skinnedMeshRenderer.SetMaterials(defaultMaterials.ToList());
        else
            meshRenderer.SetMaterials(defaultMaterials.ToList());

    }
}
