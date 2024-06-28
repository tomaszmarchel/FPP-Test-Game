using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] int doorValue;

    [SerializeField] BoxCollider doorTrigger;
    [SerializeField] Transform doorPivotPoint;

    [SerializeField] ParticleSystem fireParticle;
    [SerializeField] Transform firePoint;

    [SerializeField] Room myRoom;

    public bool doorDestroyded = false;

    public bool doorFirstCheck = false;
    public bool doorNeutralized = false;
    public bool doorCheckedAfterNeutralization = false;


    void Start()
    {
        doorValue = Random.Range(1, 9);
    }

    public void OnInteraction()
    {
        if (!doorFirstCheck || !doorNeutralized || !doorCheckedAfterNeutralization || doorValue != 0)
            DestroyDoor();
        else
            OpenDoor(true);
        /*
        if (doorValue == 0)
        {
            OpenDoor(true);
        }*/
    }

    private void OpenDoor(bool againMeasurmentDone)
    {
        if (againMeasurmentDone)
            GameStatistics.correctNeutralizedDoors++;

        transform.Rotate(0, 90f, 0, Space.Self);
        if (doorTrigger != null)
            Destroy(doorTrigger.gameObject);
    }

    public void DestroyDoor()
    {
        doorDestroyded = true;

        if (!doorFirstCheck)
            GameStatistics.noMeasurementError++;

        GameStatistics.noMeasurementError++;

        if (doorTrigger != null)
            Destroy(doorTrigger.gameObject);

        Player.Instance.DecreasePlayerHP();
        Instantiate(fireParticle, firePoint);

        myRoom.RoomDestroyded();
    }

    public int GetDoorValue()
    {
        return doorValue;
    }

    public void NeutralizeDoor()
    {
        doorValue = 0;
        doorNeutralized = true;
    }
}
