using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustmentRing : MonoBehaviour
{
    private int minRingValue = 0;
    private int maxRingValue = 9;

    private int minRingValuePlusOne = 1;
    private int maxRingValueMinusOne = 8;



    // Start is called before the first frame update
    void Start()
    {
        GameInput.Instance.OnDecreaseRing += GameInput_OnDecreaseRing;
        GameInput.Instance.OnIncreaseRing += GameInput_OnIncreaseRing;
    }

    private void GameInput_OnIncreaseRing(object sender, System.EventArgs e)
    {
        if (Player.Instance.adjustmentRingValue > maxRingValueMinusOne) 
            Player.Instance.adjustmentRingValue = minRingValue;
        else
            Player.Instance.adjustmentRingValue++;
    }

    private void GameInput_OnDecreaseRing(object sender, System.EventArgs e)
    {
        if (Player.Instance.adjustmentRingValue < minRingValuePlusOne)
            Player.Instance.adjustmentRingValue = maxRingValue;
        else
            Player.Instance.adjustmentRingValue--;
    }
}
