using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField] TMP_Text interactionText;
    [SerializeField] UIPlayerHPController UIPlayerHPController;
    [SerializeField] UISummaryController UISummaryController;

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
        if (interactionText != null)
        {
            interactionText.gameObject.SetActive(false);
        }
    }

    public void DecreasePlayerHPUI()
    {
        UIPlayerHPController.DecreasePlayerHP();
    }

    public void ShowStatistics()
    {
        if (UISummaryController.gameObject.activeSelf)
            return;

        UISummaryController.gameObject.SetActive(true);
        UISummaryController.UpdateStatistics();
    }
}
