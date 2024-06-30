using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WardrobeController : MonoBehaviour
{
    public static WardrobeController Instance { get; private set; }

    [SerializeField] private Wardrobe[] allWardrobes;
    private Wardrobe selectedWardrobe;

    private void Awake()
    {
        Instance = this;

        allWardrobes = GetComponentsInChildren<Wardrobe>();
    }

    public void SetSelectedWardrobe(Wardrobe newSelectedWardrobe)
    {
        if (selectedWardrobe == null)
        {
            selectedWardrobe = newSelectedWardrobe;}
        else
        {
            if (newSelectedWardrobe != selectedWardrobe)
            {
                selectedWardrobe.OnUntarget();
                selectedWardrobe = null;
            }
            else
            {
                if (selectedWardrobe.GetWardobeState() != Wardrobe.WardrobeState.Opened)
                    selectedWardrobe.TryToOpen();
            }
        }
    }

    public bool IsAnyOtherWardrobeOpen(Wardrobe asker)
    {
        foreach (var wardrobe in allWardrobes)
        {
            if (wardrobe == asker)
                continue;

            if (wardrobe.GetWardobeState() != Wardrobe.WardrobeState.Closed)
                return true;
        }
        return false;
    }
}
