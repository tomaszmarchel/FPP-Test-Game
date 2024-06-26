using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveableObjectParent
{
    public Transform GetSpawnPoint();

    public void SetMoveableObject(MoveableObject moveableObject);

    public MoveableObject GetMoveableObject();

    public void ClearMoveableObject();

    public bool HasSelectedMoveableObject();
}
