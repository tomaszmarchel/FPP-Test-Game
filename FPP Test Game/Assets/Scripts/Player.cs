using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    [SerializeField] GameInput gameInput;
    [SerializeField] Rifle rifle;
    [SerializeField] MeasuringDevice measuringDevice;
    
    public event EventHandler OnRifleShootEvent;

    private Door onInteractionDoor;

    private int playerHP = 3;
    private bool canInteract = false;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        GameInput.Instance.OnWeaponShoot += GameInput_OnWeaponShoot;
        GameInput.Instance.OnDoorInteraction += GameInput_OnInteraction;
    }

    // EVENT LISTENERS
    #region EVENT LISTENERS
    private void GameInput_OnInteraction(object sender, System.EventArgs e)
    {
        if (canInteract)
        {
            onInteractionDoor.OnInteraction();
        }
    }

    private void GameInput_OnWeaponShoot(object sender, System.EventArgs e)
    {
        rifle.Shoot();
        OnRifleShootEvent?.Invoke(this, EventArgs.Empty);
    }
    #endregion

    public void DecreasePlayerHP()
    {
        playerHP--;
        UIManager.Instance.DecreasePlayerHPUI();

        if (playerHP < 1)
        {
            GameManager.Instance.GameOver();
        }
    }

    public int GetPlayerHP()
    { 
        return playerHP; 
    }

    public void SetPlayerCanInteract(bool value)
    {
        canInteract = value;
    }

    public void SetPlayerInteractionDoors(Door door)
    {
        this.onInteractionDoor = door;
    }
}

