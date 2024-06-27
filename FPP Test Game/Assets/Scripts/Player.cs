using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    [SerializeField] GameInput gameInput;
    [SerializeField] Rifle rifle;
    [SerializeField] MeasuringDevice measuringDevice;


    private int playerHP = 3;
    public int adjustmentRingValue = 0;

    public bool canInteract = false;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        GameInput.Instance.OnWeaponShoot += GameInput_OnWeaponShoot;
    }

    private void GameInput_OnWeaponShoot(object sender, System.EventArgs e)
    {
        rifle.Shoot();
    }

    public void DecreasePlayerHP()
    {
        playerHP--;
    }
}

