using UnityEngine;

public class Rifle : MonoBehaviour
{
    [SerializeField] AdjustmentRing adjustmentRing;
    [SerializeField] Transform shootStartPoint;

    [SerializeField] LayerMask doorLayerMask;
    [SerializeField] LayerMask wallLayerMask;

    private Player owner;

    // Start is called before the first frame update
    void Start()
    {
        owner = Player.Instance;
    }

    public void Shoot()
    {
        owner.OnRifleShoot();


        // CAN ADD PARTICLES 


        Physics.Raycast(shootStartPoint.position, shootStartPoint.forward, out RaycastHit doorHitInfo, 20f, doorLayerMask);
        if (doorHitInfo.transform != null)
        {
            DoorShoot(doorHitInfo);
        }

        Physics.Raycast(shootStartPoint.position, shootStartPoint.forward, out RaycastHit wallHitInfo, 20f);
        if (wallHitInfo.transform != null)
        {
            var hittedSlot = wallHitInfo.transform;
            if (hittedSlot.TryGetComponent<Wall>(out Wall wall))
            {
                wall.OnHit(adjustmentRing.GetRingValue());
            }
        }
    }

    private void DoorShoot(RaycastHit raycastHit)
    {
        var hittedSlot = raycastHit.transform;
        if (hittedSlot.TryGetComponent<Door>(out Door door))
        {
            var adjustmentRingValue = adjustmentRing.GetRingValue();
            var doorValue = door.GetDoorValue();

            if (adjustmentRingValue == doorValue)
            {
                if (door.doorFirstCheck)
                    door.NeutralizeDoor();
            }
            else if (adjustmentRingValue > doorValue)
            {
                GameStatistics.tooHighRingValueDoorsError++;
            }
            else if (adjustmentRingValue < doorValue)
            {
                GameStatistics.tooLowRingValueDoorsError++;
            }
        }
    }



    public int GetAdjustmentRingValue()
    {
        return adjustmentRing.GetRingValue();
    }
}
