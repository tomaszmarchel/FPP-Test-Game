using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIPlayerHPController : MonoBehaviour
{
    [SerializeField] List<GameObject> playerHpPointIcons;

    public void DecreasePlayerHP()
    {
        if (Player.Instance.GetPlayerHP() >= 0) 
            playerHpPointIcons[Player.Instance.GetPlayerHP()].SetActive(false);
    }
}
