using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    
    private BaseInteractiveObject interactiveObject;

    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {


    }

    public void SetSelectedItem(Transform selectedItem)
    {
        isSelectedItemWardrobe(selectedItem);
    }

    private void isSelectedItemWardrobe(Transform selectedObject)
    {
        if (selectedObject.TryGetComponent<Wardrobe>(out Wardrobe selectedWardrobe))
        {
            interactiveObject = selectedWardrobe;
            interactiveObject.OnSelect();
        }
    }
}
