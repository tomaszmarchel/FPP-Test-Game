using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.UI.GridLayoutGroup;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    [SerializeField] GameInput gameInput;
    [SerializeField] Rifle rifle;
    [SerializeField] MeasuringDevice measuringDevice;

    public Door onInteractionDoor;

    public event EventHandler OnRifleShootEvent;

    public int playerHP = 3;
    public int adjustmentRingValue = 0;

    public bool canInteract = false;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        GameInput.Instance.OnWeaponShoot += GameInput_OnWeaponShoot;
        GameInput.Instance.OnInteraction += GameInput_OnInteraction;
    }

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
    }

    public void DecreasePlayerHP()
    {
        playerHP--;
        UIManager.Instance.DecreasePlayerHPUI();

        if (playerHP < 1)
        {
            GameManager.Instance.GameOver();
        }
    }

    public void OnRifleShoot()
    {
        OnRifleShootEvent?.Invoke(this, EventArgs.Empty);
    }
}

