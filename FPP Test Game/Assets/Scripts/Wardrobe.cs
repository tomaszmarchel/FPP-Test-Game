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

    public WardrobeState GetWardobeState()   
    {
        return state;
    }

    [SerializeField] private WardrobeState state;


    [SerializeField] private RackController rackController;

    [SerializeField] private Transform openedPoint;
    [SerializeField] private Transform closedPoint;

    private Coroutine coroutine;

    private bool amISelected = false;

    private void Start()
    {
        state = WardrobeState.Closed;
        wardrobeController = WardrobeController.Instance;

        rackController.TurnOffSlots();
    }

    public override void OnTarget()
    {
        wardrobeController.SetSelectedWardrobe(this);
        amISelected = true;
    }

    public override void OnUntarget()
    {
        amISelected = false;
        Close();
    }

    public void TryToOpen()
    {
        if (CanIOpen())
        {
           StopCorountines();
           Open();
        }
    }

    private bool CanIOpen()
    {
        if (wardrobeController.IsAnyOtherWardrobeOpen(this))
            return false;
        else
            return true;
    }

    private void Open()
    {
        if (coroutine == null)
            coroutine = StartCoroutine(OpenCoroutine());
    }

    private void Close()
    {
        if (coroutine != null)
        {
            StopCorountines();
        }
        coroutine = StartCoroutine(CloseCoroutine());
    }

    //COROUTINES
    #region OPEN/CLOSE COROUTINES

    private IEnumerator OpenCoroutine()
    {
        rackController.TurnOnSlots();

        while (state != WardrobeState.Opened)
        {
            state = WardrobeState.Opening;
            rackController.transform.position += -Vector3.left * Time.deltaTime;

            if (rackController.transform.position.x > openedPoint.transform.position.x)
            { 
                state = WardrobeState.Opened;
                rackController.transform.position = new Vector3(openedPoint.transform.position.x, rackController.transform.position.y, rackController.transform.position.z);
                coroutine = null;
                yield break;
            }
            yield return null;
        }
    }

    private IEnumerator CloseCoroutine()
    {
        while (state != WardrobeState.Closed)
        {
            state = WardrobeState.Closing;
            rackController.transform.position += Vector3.left * Time.deltaTime;

            if (rackController.transform.position.x < closedPoint.transform.position.x)
            {
                state = WardrobeState.Closed;
                rackController.transform.position = new Vector3(closedPoint.transform.position.x, rackController.transform.position.y, rackController.transform.position.z);
                rackController.TurnOffSlots();
                
                coroutine = null;
                yield break;
            }

            yield return null;
        }
    }

    private void StopCorountines()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
            coroutine = null;
        }
    }
    #endregion
}
