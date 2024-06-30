using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField] TMP_Text interactionText;
    [SerializeField] UIPlayerHPController uIPlayerHPController;
    [SerializeField] UISummaryController uISummaryController;
    [SerializeField] GameObject keyBingingsSprite;

    void Awake()
    {
        Instance = this;
        uISummaryController.gameObject.SetActive(false);
    }

    public void ShowInteractionText()
    {
        interactionText.gameObject.SetActive(true);
    }

    public void HideInteractionText()
    {
        if (interactionText != null)
        {
            interactionText.gameObject.SetActive(false);
        }
    }

    public void DecreasePlayerHPUI()
    {
        uIPlayerHPController.DecreasePlayerHP();
    }

    public void ShowStatistics()
    {
        if (uISummaryController.gameObject.activeSelf)
            return;

        keyBingingsSprite.SetActive(false);
        uISummaryController.gameObject.SetActive(true);
        uISummaryController.UpdateStatistics();
    }
}
