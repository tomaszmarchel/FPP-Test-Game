using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : MonoBehaviour
{
    [SerializeField] AdjustmentRing adjustmentRing;
    [SerializeField] Transform shootStartPoint;

    [SerializeField] LayerMask doorLayerMask;

    // Start is called before the first frame update
    void Start()
    {
        GameInput.Instance.OnWeaponShoot += GameInput_OnWeaponShoot;
    }

    private void GameInput_OnWeaponShoot(object sender, System.EventArgs e)
    {
        Shoot();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Shoot()
    {
        Physics.Raycast(shootStartPoint.position, shootStartPoint.forward, out RaycastHit hitInfo, 4f, doorLayerMask);
        if (hitInfo.transform != null)
        {
            var hittedSlot = hitInfo.transform;
            if (hittedSlot.TryGetComponent<Door>(out Door door))
            {
                var adjustmentRingValue = adjustmentRing.GetRingValue();
                var doorValue = door.GetDoorValue();

                if (adjustmentRingValue == doorValue)
                {
                    Debug.Log("good shoot");
                    // good shot
                }
                else
                {
                    Debug.Log("bad shoot");
                    // destroy doors
                }
            }
        }
        Debug.Log("shoot not in doors");
    }

    public int GetAdjustmentRingValue()
    {
        return adjustmentRing.GetRingValue();
    }
}
