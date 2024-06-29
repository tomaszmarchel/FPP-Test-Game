using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RackController : MonoBehaviour
{
    [SerializeField] private MoveableObjectSlotBase[] rackMoveableSlots;
    // ZROBIC VISUALA DO TEGO
    public void TurnOffSlots()
    {
        foreach (var slot in rackMoveableSlots)
        {
            slot.gameObject.SetActive(false);
        }
    }

    public void TurnOnSlots()
    {
        foreach (var slot in rackMoveableSlots)
        {
            slot.gameObject.SetActive(true);
        }
    }
}
