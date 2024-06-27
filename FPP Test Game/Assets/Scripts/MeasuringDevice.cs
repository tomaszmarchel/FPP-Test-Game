using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeasuringDevice : MonoBehaviour
{
    [SerializeField] private Transform cameraPosition;
    [SerializeField] private LayerMask doorLayerMask;

    [SerializeField] MeasuringDeviceVisual measuringDeviceVisual;

    // Start is called before the first frame update
    void Start()
    {
        GameInput.Instance.OnTakeMeasurement += GameInput_OnTakeMeasurement;    
    }

    private void GameInput_OnTakeMeasurement(object sender, System.EventArgs e)
    {
        Physics.Raycast(cameraPosition.position, cameraPosition.forward, out RaycastHit hitInfo, 4f, doorLayerMask);
        if (hitInfo.transform != null)
        {
            var hittedSlot = hitInfo.transform;
            if (hittedSlot.TryGetComponent<Door>(out Door door))
            {
                GetDoorValue(door);
                measuringDeviceVisual.SetVisualNumber(GetDoorValue(door));
            }
        }
        else
        {

        }


    }


    private int GetDoorValue(Door door)
    {
        return door.GetDoorValue();
    }
}
