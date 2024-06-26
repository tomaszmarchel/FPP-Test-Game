using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance { get; private set; }

    public event EventHandler OnMouseButtonDown;
    public event EventHandler OnMouseButtonUp;

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

    }
}
