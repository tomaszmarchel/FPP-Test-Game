using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] protected Room owner;
    [SerializeField] WallVisual wallVisual;
    private int wallRingValue = 0;


    public void OnHit(int ringValue)
    {
        var adjustmentRingValue = ringValue;

        if (IsWallInWallsToHit())
        {
            if (adjustmentRingValue == wallRingValue)
            {
                CorrectHit();
            }
            else
            {
                WrongRingValueHit();
            }
        }
        else
        {
            OnNextShootHit();
        }
    }

    private bool IsWallInWallsToHit()
    {
        if (owner.GetWallsToHitList().Contains(this))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public virtual void CorrectHit()
    {
        owner.DeleteWallFromList(this);
        owner.RoomFinishCheck();
        wallVisual.MarkWallVisualization(true);
    }

    public virtual void OnNextShootHit()
    {
        wallVisual.MarkWallVisualization(false);
        GameStatistics.moreThanOneShootToWallError++;
    }

    public virtual void WrongRingValueHit()
    {
        wallVisual.MarkWallVisualization(false);
        GameStatistics.wrongRingValueInRoomError++;
    }

    public WallVisual GetWallVisual()
    {
        return wallVisual;
    }
}
