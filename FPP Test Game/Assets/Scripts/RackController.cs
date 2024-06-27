using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RackController : MonoBehaviour
{
    [SerializeField] private MoveableObjectSlotBase[] moveableSlots;

    public void TurnOffSlots()
    {
        foreach (var slot in moveableSlots)
        {
            slot.gameObject.SetActive(false);
        }
    }

    public void TurnOnSlots()
    {
        foreach (var slot in moveableSlots)
        {
            slot.gameObject.SetActive(true);
        }
    }
}
