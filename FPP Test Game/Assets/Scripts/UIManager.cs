using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField] TMP_Text interactionText;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        interactionText.gameObject.SetActive(false);
    }

    public void ShowInteractionText()
    {
        interactionText.gameObject.SetActive(true);
    }

    public void HideInteractionText()
    {
        interactionText.gameObject.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
