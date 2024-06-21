using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    private Transform selectedGameObject;

    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        
    }

    public void SetSelectedItem(Transform selectedItem)
    {
        selectedGameObject = selectedItem;
    }
}
