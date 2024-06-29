using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeasuringDeviceVisual : MonoBehaviour
{
    [SerializeField] private GameObject[] numbersGameObjectsArray;
    private MeasuringDevice owner;
    
    private Coroutine coroutine;

    private float visibleTime = 1.5f;


    public void Awake()
    {
        owner = GetComponentInParent<MeasuringDevice>();
    }

    private IEnumerator TurnOnVisualValues(int value)
    {
        visibleTime = 1.5f;
        while (visibleTime > 0)
        {
            owner.SetCanDoMeasurement(false);
            visibleTime -= Time.deltaTime;
            numbersGameObjectsArray[value].gameObject.SetActive(true);
            yield return null;
        }

        numbersGameObjectsArray[value].gameObject.SetActive(false);
        coroutine = null;
        yield break;
    }

    public void SetVisualNumber(int value)
    {
        if (coroutine == null)
            coroutine = StartCoroutine(TurnOnVisualValues(value));
    }
}
