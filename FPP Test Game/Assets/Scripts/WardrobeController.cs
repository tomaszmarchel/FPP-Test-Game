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

    public void SetSelectedWardrobe(Wardrobe newSelectedWardrobe)
    {
        if (selectedWardrobe == null)
        {
            Debug.Log("seleceted new wardrobe");
            selectedWardrobe = newSelectedWardrobe;

            // first selected wardrobe
            // open wardrobe
        }
        else
        {
            if (newSelectedWardrobe != selectedWardrobe)
            {
                Debug.Log("deseleceted wardrobe" + selectedWardrobe.name);
                selectedWardrobe.OnDeselect();
                selectedWardrobe = null;

               

                // close old
            }
            else
            {
                if (selectedWardrobe.GetWardobeState() != Wardrobe.WardrobeState.Opened)
                    selectedWardrobe.TryToOpen();
            }
        }
    }



    public bool isAnyOtherWardrobeOpen(Wardrobe asker)
    {
        foreach (var wardrobe in wardrobes)
        {
            if (wardrobe == asker)
                continue;

            if (wardrobe.GetWardobeState() != Wardrobe.WardrobeState.Closed)
                return true;
        }
        return false;
    }
    
}
