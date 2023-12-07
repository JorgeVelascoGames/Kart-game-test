using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Arch.Data;

public class MainMenuUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private TextMeshProUGUI bestTimeText;

    private void Awake()
    {
        DataManager.DataLoaded += DisplayUI;
    }

    private void DisplayUI()
    {
        coinText.text = "Total coins: " + DataManager.Instance.score.ToString();
        bestTimeText.text = "Best time: 0:" + ((int)DataManager.Instance.bestTime).ToString();
    }

}
