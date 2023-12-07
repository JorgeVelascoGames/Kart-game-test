using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Arch.Data;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [Header("Configuration")]
    [SerializeField] private int pointsPerCoin = 1;

    [Header("Game score")]
    [SerializeField] private int runScore = 0;
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Start()
    {
        Debug.Log(transform.parent.name);
        Coin.CoinCollected += OnCoinCollected;
        UpdateUI();
    }

    private void OnDisable()
    {
        Coin.CoinCollected -= OnCoinCollected;
    }

    private void OnCoinCollected()
    {
        runScore += pointsPerCoin;
        DataManager.Instance.score += pointsPerCoin;
        UpdateUI();
    }

    private void UpdateUI()
    {
        scoreText.text = "Coins: " + runScore;
    }
}
