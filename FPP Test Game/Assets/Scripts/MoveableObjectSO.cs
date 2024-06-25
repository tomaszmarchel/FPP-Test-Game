using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class MoveableObjectSO : ScriptableObject
{
    public Transform prefab;
    public MoveableObjectsTypes.Type itemType;
    public string itemName;
}
