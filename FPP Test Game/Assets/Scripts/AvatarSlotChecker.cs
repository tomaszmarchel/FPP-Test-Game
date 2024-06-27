using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarSlotChecker : MonoBehaviour
{
    public static AvatarSlotChecker Instance { get; private set; }

    [SerializeField] private MoveableAvatarSlot[] MoveableAvatarSlots;

    private void Awake()
    {
        Instance = this;    
    }

    private void Start()
    {
        GameInput.Instance.OnItemDrop += GameInput_OnItemDrop;
    }

    private void GameInput_OnItemDrop(object sender, System.EventArgs e)
    {
        if(AreAllItemsEquiped())
            FirstStageManager.Instance.GoToSecondStage();

    }

    public bool AreAllItemsEquiped()
    {
        foreach (var item in MoveableAvatarSlots)
        {
            if (item.GetMoveableObject() != null)
                continue;
            else
                return false;
        }
        return true;
    }
}
