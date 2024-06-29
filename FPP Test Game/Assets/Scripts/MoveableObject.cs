using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MoveableObject : MonoBehaviour
{
    [SerializeField] MoveableObjectSO moveableObjectSO;

    private IMoveableObjectParent moveableObjectParent;

    public bool isPlayerTarget = false;
    public bool selectedOnMe = false;

    public bool hasSkinnedMeshRenderer = false;

    [SerializeField] MeshRenderer[] meshRenderers;
    [SerializeField] SkinnedMeshRenderer[] skinnedMeshRenderers;

    [SerializeField] Material[] defaultMaterials;
    [SerializeField] Material[] outlineYellowMaterialArray;
    [SerializeField] Material[] outlineGreenMaterialArray;

    public enum OutlineState
    {
        None,
        Targeted,
        Seleceted
    }

    private OutlineState state;

    private void Awake()
    {
        state = OutlineState.None;
    }

    public void MoveableObjectIsPlayerTarget()
    {
        if (GameInput.Instance.isMouseButtonDown)
        {
            state = OutlineState.Seleceted;
        }
        else
        {
            state = OutlineState.Targeted;
        }

        if (state == OutlineState.Seleceted)
        {
            SetMoveableObjectParent(FirstStagePlayer.Instance);
        }

        ShowOutline();
    }

    public void MoveableObjectIsNotPlayerTarget()
    {
        HideOutline();
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

    //SHOW HIDE OUTLINE
    #region SHOW/HIDE OUTLINE
    private void ShowOutline()
    {
        if (state == OutlineState.Targeted)
        {
            if (hasSkinnedMeshRenderer)
            {
                foreach(SkinnedMeshRenderer skinnedMeshRenderer in skinnedMeshRenderers)
                    skinnedMeshRenderer.SetMaterials(outlineYellowMaterialArray.ToList());
            }
            else
            {
                foreach (MeshRenderer meshRenderer in meshRenderers)
                    meshRenderer.SetMaterials(outlineYellowMaterialArray.ToList());
            }

        }
        else if (state == OutlineState.Seleceted)
        {
            if (hasSkinnedMeshRenderer)
            {
                foreach (SkinnedMeshRenderer skinnedMeshRenderer in skinnedMeshRenderers)
                    skinnedMeshRenderer.SetMaterials(outlineGreenMaterialArray.ToList());
            }
            else
            {
                foreach (MeshRenderer meshRenderer in meshRenderers)
                    meshRenderer.SetMaterials(outlineGreenMaterialArray.ToList());
            }
        }
    }

    private void HideOutline()
    {
        state = OutlineState.None;

        if (hasSkinnedMeshRenderer)
        {
            foreach (SkinnedMeshRenderer skinnedMeshRenderer in skinnedMeshRenderers)
                skinnedMeshRenderer.SetMaterials(defaultMaterials.ToList());
        }
        else
        {
            foreach (MeshRenderer meshRenderer in meshRenderers)
                meshRenderer.SetMaterials(defaultMaterials.ToList());
        }
    }
    #endregion
}
