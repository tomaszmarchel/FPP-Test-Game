using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustmentRingVisual : MonoBehaviour
{
// Start is called before the first frame update
    void Start()
    {
        GameInput.Instance.OnDecreaseRing += GameInput_OnDecreaseRing;
        GameInput.Instance.OnIncreaseRing += GameInput_OnIncreaseRing;
    }

    private void GameInput_OnIncreaseRing(object sender, System.EventArgs e)
    {
        transform.Rotate(0, -36f, 0, Space.Self);
    }

    private void GameInput_OnDecreaseRing(object sender, System.EventArgs e)
    {
        transform.Rotate(0, 36f, 0, Space.Self);
    }
}
