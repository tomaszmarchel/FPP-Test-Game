using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    [SerializeField] GameInput gameInput;

    public int adjustmentRingValue = 0;


    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update

}

