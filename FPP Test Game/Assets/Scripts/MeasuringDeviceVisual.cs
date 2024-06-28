using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeasuringDeviceVisual : MonoBehaviour
{
    [SerializeField] private GameObject[] visualNumbers;
    private MeasuringDevice owner;

    private float visibleTime = 1.5f;

    private Coroutine coroutine;


    public void Awake()
    {
        owner = GetComponentInParent<MeasuringDevice>();
    }

    private void CoroutineCheck()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
            coroutine = null;
        }
    }

    private IEnumerator TurnOnVisualValues(int value)
    {
        visibleTime = 1.5f;
        while (visibleTime > 0)
        {
            owner.canDoMeasurement = false;
            visibleTime -= Time.deltaTime;
            visualNumbers[value].gameObject.SetActive(true);
            yield return null;
        }

        visualNumbers[value].gameObject.SetActive(false);
        coroutine = null;
        yield break;
    }

    public void SetVisualNumber(int value)
    {
        //CoroutineCheck();
        if (coroutine == null)
            coroutine = StartCoroutine(TurnOnVisualValues(value));
    }
}
