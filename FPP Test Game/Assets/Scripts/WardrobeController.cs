using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WardrobeController : MonoBehaviour
{
    public static WardrobeController Instance { get; private set; }

    [SerializeField] private Wardrobe[] wardrobes;

    public Wardrobe selectedWardrobe;

    private void Awake()
    {
        Instance = this;
    }

    public bool isAnyOtherWardrobeAlreadySelected(Wardrobe wardrobe)
    {
        if (selectedWardrobe != null)
        {
            if (selectedWardrobe != wardrobe)
                return true;
            else 
                return false;
        }
        else
            return false;
    }

}
