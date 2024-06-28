using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeasuringDeviceVisual : MonoBehaviour
{
    [SerializeField] private GameObject[] visualNumbers;
    private float visibleTime = 2f;

    private Coroutine coroutine;


    // Start is called before the first frame update

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
        visibleTime = 2f;
        while (visibleTime > 0)
        {
            visibleTime -= Time.deltaTime;
            visualNumbers[value].gameObject.SetActive(true);
            yield return null;
        }

        visualNumbers[value].gameObject.SetActive(false);
        yield break;
    }

    public void SetVisualNumber(int value)
    {
        CoroutineCheck();
        coroutine = StartCoroutine(TurnOnVisualValues(value));
    }
}
