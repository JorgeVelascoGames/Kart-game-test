using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class UIScoreTracker : MonoBehaviour
{
	private TextMeshProUGUI textField;

	[Tooltip("The text before the number")]
	[SerializeField]private string textBeforeScore;

	[Tooltip("The ammount of points we add to the score per call")]
	[SerializeField] private int pointsPerCall;

	private int score;

	private void Awake()
	{
		textField = GetComponent<TextMeshProUGUI>();
		score = 0;
	}

	private void OnEnable()
	{
		Coin.CoinCollected += UpdateUI;
	}

	private void OnDisable()
	{
		Coin.CoinCollected -= UpdateUI;
	}

	private void UpdateUI()
	{
		score++;
		textField.text = textBeforeScore + score.ToString();
	}
}
