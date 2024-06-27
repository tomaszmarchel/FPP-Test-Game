using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance { get; private set; }

    public event EventHandler OnItemDrop;

    public event EventHandler OnDecreaseRing;
    public event EventHandler OnIncreaseRing;

    public bool isMouseButtonDown = false;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
            isMouseButtonDown = true;
        else
            isMouseButtonDown = false;
    
        if (Input.GetMouseButtonUp(0))
            OnItemDrop(this, EventArgs.Empty);

        if (Input.GetKeyDown(KeyCode.Q))
            OnDecreaseRing(this, EventArgs.Empty);

        if (Input.GetKeyDown(KeyCode.E))
            OnIncreaseRing(this, EventArgs.Empty);

    }
}
