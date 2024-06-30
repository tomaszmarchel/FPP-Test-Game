using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarSlotChecker : MonoBehaviour
{
    public static AvatarSlotChecker Instance { get; private set; }

    [SerializeField] private MoveableAvatarSlot[] moveableAvatarSlots;

    private void Awake()
    {
        Instance = this;    
    }

    public void CheckAllItemsAreEquipped()
    {
        if (AreAllItemsEquiped())
        {
            GameManager.Instance.LoadSecondStage();
        }
    }

    private bool AreAllItemsEquiped()
    {
        foreach (var item in moveableAvatarSlots)
        {
            if (item.GetMoveableObject() != null)
                continue;
            else
                return false;
        }
        return true;
    }
}
