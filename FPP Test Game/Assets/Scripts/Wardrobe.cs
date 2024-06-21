using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wardrobe : BaseInteractiveObject
{
    public enum WardrobeState
    {
        Opening,
        Opened,
        Closing,
        Closed
    }

    private WardrobeState state;

    public bool amISelected = false;

    public override void OnSelect()
    {
        // Open WArdrobe

        Debug.Log("im wardrobe");

    }

}
