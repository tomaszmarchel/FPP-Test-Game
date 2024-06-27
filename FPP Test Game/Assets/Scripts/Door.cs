using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] int doorValue;

    // Start is called before the first frame update
    void Start()
    {
        doorValue = Random.Range(1, 9);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetDoorValue()
    {
        Debug.Log(doorValue);
        return doorValue;
    }

    public void NeutralizeDoor()
    {
        doorValue = 0;
    }
}
