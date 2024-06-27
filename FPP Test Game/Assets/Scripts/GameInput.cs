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

    public event EventHandler OnTakeMeasurement;
    public event EventHandler OnWeaponShoot;

    public bool isMouseButtonDown = false;

    InputActions inputActions;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;

        inputActions = new InputActions();
        inputActions.Player.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.gameStage == GameManager.GameStage.FirstStage)
        {
            if (Input.GetMouseButton(0))
                isMouseButtonDown = true;
            else
                isMouseButtonDown = false;

            if (Input.GetMouseButtonUp(0))
                OnItemDrop?.Invoke(this, EventArgs.Empty);

            if (Input.GetKeyDown(KeyCode.P))
                GameManager.Instance.GoToSecondStage();
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Q))
                OnDecreaseRing?.Invoke(this, EventArgs.Empty);

            if (Input.GetKeyDown(KeyCode.E))
                OnIncreaseRing?.Invoke(this, EventArgs.Empty);

            if (Input.GetKeyDown(KeyCode.R))
                OnTakeMeasurement?.Invoke(this, EventArgs.Empty);

            if (Input.GetMouseButtonDown(0))
                OnWeaponShoot?.Invoke(this, EventArgs.Empty);

        }
    }
}
