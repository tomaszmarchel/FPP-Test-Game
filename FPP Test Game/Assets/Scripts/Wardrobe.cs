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

    [SerializeField] private Transform rack;
    [SerializeField] private Transform openedPoint;
    [SerializeField] private Transform closedPoint;

    [SerializeField] private WardrobeState state;
    private Coroutine coroutine;

    public WardrobeState GetWardobeState()
    {
        return state;
    }

    public bool amISelected = false;

    private void Start()
    {
        wardrobeController = WardrobeController.Instance;
        state = WardrobeState.Closed;
    }

    private void Update()
    {
        // if am im selected
    }

    public override void OnSelect()
    {
        // Open WArdrobe
        wardrobeController.SetSelectedWardrobe(this);
        amISelected = true;
    }

    public override void OnDeselect()
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
        else
            WaitToOpen();
    }

    public void Open()
    {
        if (coroutine == null)
            coroutine = StartCoroutine(OpenCoroutine());
    }

    public void Close()
    {
        if (coroutine != null)
        {
            StopCorountines();
        }
        coroutine = StartCoroutine(CloseCoroutine());
    }

    public void WaitToOpen()
    {

    }

    public bool CanIOpen()
    {
        if (wardrobeController.isAnyOtherWardrobeOpen(this))
            return false;
        else
            return true;
    }

    private void StopCorountines()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
            coroutine = null;
        }
    }


    public IEnumerator OpenCoroutine()
    {
        while (state != WardrobeState.Opened)
        {
            state = WardrobeState.Opening;
            rack.transform.position += -Vector3.left * Time.deltaTime;

            if (rack.transform.position.x > openedPoint.transform.position.x)
            { 
                state = WardrobeState.Opened;
                rack.transform.position = new Vector3(openedPoint.transform.position.x, rack.transform.position.y, rack.transform.position.z);
                coroutine = null;
                yield break;
            }
            yield return null;
        }
    }

    public IEnumerator CloseCoroutine()
    {
        while (state != WardrobeState.Closed)
        {
            state = WardrobeState.Closing;
            rack.transform.position += Vector3.left * Time.deltaTime;

            if (rack.transform.position.x < closedPoint.transform.position.x)
            {
                state = WardrobeState.Closed;
                rack.transform.position = new Vector3(closedPoint.transform.position.x, rack.transform.position.y, rack.transform.position.z);
                coroutine = null;
                yield break;
            }

            yield return null;
        }
    }

}
