using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wardrobe : BaseInteractiveObject
{
    private WardrobeController wardrobeController;

    public enum WardrobeState
    {
        WaitingToOpen,
        Opening,
        Opened,
        Closing,
        Closed
    }

    private WardrobeState state;

    public bool amISelected = false;

    private void Start()
    {
        wardrobeController = WardrobeController.Instance;
    }

    private void Update()
    {
        // if am im selected
    }

    public override void OnSelect()
    {
        // Open WArdrobe

        if (wardrobeController.isAnyOtherWardrobeAlreadySelected(this))
        {
            wardrobeController.selectedWardrobe.OnDeselect();
            wardrobeController.selectedWardrobe = null;
        }
        else
        {
            Debug.Log(transform.name + " im seleceted");
            wardrobeController.selectedWardrobe = this;
            amISelected = true;
        }
    }

    public override void OnDeselect()
    {
        amISelected = false;
        Debug.Log(transform.name + " im deseleceted");
    }

}
