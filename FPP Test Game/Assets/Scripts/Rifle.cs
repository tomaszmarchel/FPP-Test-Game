using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : MonoBehaviour
{
    [SerializeField] AdjustmentRing adjustmentRing;
    [SerializeField] Transform shootStartPoint;

    [SerializeField] LayerMask doorLayerMask;

    private Player owner;

    // Start is called before the first frame update
    void Start()
    {
        owner = Player.Instance;
    }

    public void Shoot()
    {
        // Add visuals 


        Physics.Raycast(shootStartPoint.position, shootStartPoint.forward, out RaycastHit hitInfo, 4f, doorLayerMask);
        if (hitInfo.transform != null)
        {
            var hittedSlot = hitInfo.transform;
            if (hittedSlot.TryGetComponent<Door>(out Door door))
            {
                var adjustmentRingValue = adjustmentRing.GetRingValue();
                var doorValue = door.GetDoorValue();

                if (doorValue == 0)
                {
                    door.DestroyDoor();
                    owner.DecreasePlayerHP();
                }
                else
                {
                    if (adjustmentRingValue == doorValue)
                    {
                        door.NeutralizeDoor();
                    }
                    else
                    {
                        door.DestroyDoor();
                        owner.DecreasePlayerHP();

                        if (adjustmentRingValue > doorValue)
                        {
                            GameStatistics.higherRingValue++;
                        }
                        else if (adjustmentRingValue < doorValue)
                        {
                            GameStatistics.lowerRingValue++;
                        }
                    }
                }
            }
        }
    }


    public int GetAdjustmentRingValue()
    {
        return adjustmentRing.GetRingValue();
    }
}
