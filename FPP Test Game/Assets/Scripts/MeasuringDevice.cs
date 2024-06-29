using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MeasuringDevice : MonoBehaviour
{
    [SerializeField] MeasuringDeviceVisual measuringDeviceVisual;

    [SerializeField] private Transform cameraPosition;
    
    [SerializeField] private LayerMask doorLayerMask;

    private bool canDoMeasurement = true;

    void Start()
    {
        GameInput.Instance.OnTakeMeasurement += GameInput_OnTakeMeasurement;
    }

    private void GameInput_OnTakeMeasurement(object sender, System.EventArgs e)
    {
        RaycastToDoor();
    }

    private void RaycastToDoor()
    {
        Physics.Raycast(cameraPosition.position, cameraPosition.forward, out RaycastHit hitInfo, 6f, doorLayerMask);
        if (hitInfo.transform != null)
        {
            var hittedSlot = hitInfo.transform;
            if (hittedSlot.TryGetComponent<Door>(out Door door))
            {
                if (!door.doorDestroyded)
                {
                    GetDoorValue(door);
                    measuringDeviceVisual.SetVisualNumber(GetDoorValue(door));

                    door.doorFirstCheck = true;

                    if (door.doorNeutralized)
                        door.doorCheckedAfterNeutralization = true;
                }
            }
        }
    }

    private int GetDoorValue(Door door)
    {
        return door.GetDoorValue();
    }

    public void SetCanDoMeasurement(bool value)
    {
        canDoMeasurement = value;
    }
}
