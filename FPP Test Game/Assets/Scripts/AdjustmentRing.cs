using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustmentRing : MonoBehaviour
{
    private int minRingValue = 0;
    private int maxRingValue = 9;

    private int minRingValuePlusOne = 1;
    private int maxRingValueMinusOne = 8;

    private int ringValue = 0;

    // Start is called before the first frame update
    void Start()
    {
        GameInput.Instance.OnDecreaseRing += GameInput_OnDecreaseRing;
        GameInput.Instance.OnIncreaseRing += GameInput_OnIncreaseRing;
    }

    private void GameInput_OnIncreaseRing(object sender, System.EventArgs e)
    {
        if (ringValue > maxRingValueMinusOne)
            ringValue = minRingValue;
        else
            ringValue++;
    }

    private void GameInput_OnDecreaseRing(object sender, System.EventArgs e)
    {
        if (ringValue < minRingValuePlusOne)
            ringValue = maxRingValue;
        else
            ringValue--;
    }

    public int GetRingValue()
    {
        return ringValue;
    }
}
