using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
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
                OnWallHit(wall);
            }
        }
    }

    private void OnWallHit(Wall wall)
    {
        var adjustmentRingValue = adjustmentRing.GetRingValue();
        var wallValue = wall.GetWallRingValue();

        if (adjustmentRingValue == wallValue)
        {
            wall.WallOnHit();
        }
        else
        {
            GameStatistics.badRingValueInRoomError++;
            wall.IncorrectWallMark();
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
                if (door.doorFirstCheck && door.doorCheckedAfterNeutralization)
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


            /*
            if (!door.doorFirstCheck)
            {
                if (adjustmentRingValue > doorValue)
                {
                    GameStatistics.tooHighRingValueDoorsError++;
                }
                else if (adjustmentRingValue < doorValue)
                {
                    GameStatistics.tooLowRingValueDoorsError++;
                }

                //door.DestroyDoor();
            }
           // else if (doorValue == 0)
            //{
           //     door.DestroyDoor();
           // }
            else
            {
                if (adjustmentRingValue == doorValue)
                {
                    door.NeutralizeDoor();
                }
                else
                {
                    //door.DestroyDoor();

                    if (adjustmentRingValue > doorValue)
                    {
                        GameStatistics.tooHighRingValueDoorsError++;
                    }
                    else if (adjustmentRingValue < doorValue)
                    {
                        GameStatistics.tooLowRingValueDoorsError++;
                    }
                }
            }*/
        }
    }



    public int GetAdjustmentRingValue()
    {
        return adjustmentRing.GetRingValue();
    }
}
