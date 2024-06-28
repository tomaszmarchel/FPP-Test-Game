using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.GridLayoutGroup;

public class WallSeparated : Wall
{
    [SerializeField] Wall secondWallPart;

    public override void CorrectWallMark()
    {
        base.CorrectWallMark();

        secondWallPart.GetWallVisual().MarkWallVisualization(true);
        owner.DeleteWallFromList(secondWallPart);
    }

    public override void IncorrectWallMark()
    {
        base.IncorrectWallMark();

        secondWallPart.GetWallVisual().MarkWallVisualization(false);
    }
}
