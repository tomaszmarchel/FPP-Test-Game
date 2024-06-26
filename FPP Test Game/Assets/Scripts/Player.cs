using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    
    private BaseInteractiveObject interactiveObject;
    private MoveableObject aimedMoveableObject;



    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {


    }

    public void SetSelectedItem(Transform selectedItem)
    {
        if (selectedItem.TryGetComponent<Wardrobe>(out Wardrobe selectedWardrobe))
        {
            WardrobeInteraction(selectedWardrobe);
        }
        else if (selectedItem.TryGetComponent<MoveableObject>(out MoveableObject moveableObject))
        {
            MoveableItemAimedAt(moveableObject);
        }
    }

    private void WardrobeInteraction(Wardrobe selectedWardrobe)
    {
        interactiveObject = selectedWardrobe;
        interactiveObject.OnSelect();
    }

    private void MoveableItemAimedAt(MoveableObject moveableObject)
    {
        aimedMoveableObject = moveableObject;
        aimedMoveableObject.isAimedOnMe = true;
    }


}
