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

    public event EventHandler OnInteraction;

    public event EventHandler OnGameOverExit;

    public bool isMouseButtonDown = false;
    private Player player;


    InputActions inputActions;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;

        inputActions = new InputActions();
        inputActions.Player.Enable();

        player = Player.Instance;
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
        else if (GameManager.Instance.gameStage == GameManager.GameStage.SecondStage)
        {
            if (Input.GetKeyDown(KeyCode.Z))
                OnDecreaseRing?.Invoke(this, EventArgs.Empty);

            if (Input.GetKeyDown(KeyCode.X))
                OnIncreaseRing?.Invoke(this, EventArgs.Empty);

            if (Input.GetKeyDown(KeyCode.R))
                OnTakeMeasurement?.Invoke(this, EventArgs.Empty);

            if (player.canInteract)
                if (Input.GetKeyDown(KeyCode.E))
                    OnInteraction?.Invoke(this, EventArgs.Empty);

            if (Input.GetMouseButtonDown(0))
                OnWeaponShoot?.Invoke(this, EventArgs.Empty);
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                OnGameOverExit?.Invoke(this, EventArgs.Empty);
        }
    }
}
