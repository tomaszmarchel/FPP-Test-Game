using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance { get; private set; }

    //EVENTS
    public event EventHandler OnMouseButtonUp;
    public event EventHandler OnDecreaseRing;
    public event EventHandler OnIncreaseRing;
    public event EventHandler OnTakeMeasurement;
    public event EventHandler OnWeaponShoot;
    public event EventHandler OnDoorInteraction;
    public event EventHandler OnGameOverExit;

    public bool isMouseButtonDown = false;

    InputActions inputActions;

    void Awake()
    {
        Instance = this;

        inputActions = new InputActions();
        inputActions.Player.Enable();
    }

    void Update()
    {
        if (GameManager.Instance.gameStage == GameManager.GameStage.FirstStage)
        {
            if (Input.GetMouseButton(0))
                isMouseButtonDown = true;
            else
                isMouseButtonDown = false;

            if (Input.GetMouseButtonUp(0))
                OnMouseButtonUp?.Invoke(this, EventArgs.Empty);

            //TO DEBUG
            if (Input.GetKeyDown(KeyCode.P))
                GameManager.Instance.LoadSecondStage();
        }
        else if (GameManager.Instance.gameStage == GameManager.GameStage.SecondStage)
        {
            if (Input.GetKeyDown(KeyCode.Z))
                OnDecreaseRing?.Invoke(this, EventArgs.Empty);

            if (Input.GetKeyDown(KeyCode.X))
                OnIncreaseRing?.Invoke(this, EventArgs.Empty);

            if (Input.GetKeyDown(KeyCode.R))
                OnTakeMeasurement?.Invoke(this, EventArgs.Empty);

            if (Input.GetKeyDown(KeyCode.E))
                OnDoorInteraction?.Invoke(this, EventArgs.Empty);

            if (Input.GetMouseButtonDown(0))
                OnWeaponShoot?.Invoke(this, EventArgs.Empty);
        }
        else if (GameManager.Instance.gameStage == GameManager.GameStage.SummaryStage)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
                OnGameOverExit?.Invoke(this, EventArgs.Empty);


            }
        }
    }
}
