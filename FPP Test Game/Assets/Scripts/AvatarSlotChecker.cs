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

    private void Start()
    {
        GameInput.Instance.OnMouseButtonUp += GameInput_OnMouseButtonUp;
    }

    private void GameInput_OnMouseButtonUp(object sender, System.EventArgs e)
    {
        if(AreAllItemsEquiped())
            GameManager.Instance.LoadSecondStage();
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
