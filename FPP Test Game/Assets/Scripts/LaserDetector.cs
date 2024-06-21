using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDetector : MonoBehaviour
{
    private Transform contactPoint;
    [SerializeField] Transform rayStartPoint;

    private void Update()
    {
        Physics.Raycast(rayStartPoint.position, rayStartPoint.forward, out RaycastHit hitInfo, 20f);

        if (hitInfo.transform != null)
        {
            var hittedGameObjectParent = hitInfo.transform;
            //Player.Instance.SetSelectedItem(hittedGameObjectParent);
            Debug.Log(hittedGameObjectParent.name);
        }
    }
}
