using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] protected Room owner;
    [SerializeField] WallVisual wallVisual;
    private int wallRingValue = 0;

    public void WallOnHit()
    {
        IsWallInWallsToHit();
    }

    private void IsWallInWallsToHit()
    {
        if (owner.GetWallsToHitList().Contains(this))
        {
            CorrectWallMark();
        }
        else
        {
            IncorrectWallMark();
        }
    }

    public virtual void CorrectWallMark()
    {
        wallVisual.MarkWallVisualization(true);
        owner.DeleteWallFromList(this);

        owner.RoomFinishCheck();
    }

    public virtual void IncorrectWallMark()
    {
        wallVisual.MarkWallVisualization(false);
        GameStatistics.moreThanOneShootToWallError++;
    }

    public int GetWallRingValue()
    {
        return wallRingValue;
    }

    public WallVisual GetWallVisual()
    {
        return wallVisual;
    }
}
