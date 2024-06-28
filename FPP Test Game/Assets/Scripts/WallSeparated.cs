using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.GridLayoutGroup;

public class WallSeparated : Wall
{
    [SerializeField] Wall secondWallPart;

    public override void CorrectHit()
    {
        base.CorrectHit();

        secondWallPart.GetWallVisual().MarkWallVisualization(true);
        owner.DeleteWallFromList(secondWallPart);
    }

    public override void OnNextShootHit()
    {
        base.OnNextShootHit();

        secondWallPart.GetWallVisual().MarkWallVisualization(false);
    }

    public override void WrongRingValueHit()
    {
        base.WrongRingValueHit();
        secondWallPart.GetWallVisual().MarkWallVisualization(false);
    }
}
