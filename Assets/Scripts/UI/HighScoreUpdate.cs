using UnityEngine;
using UnityEngine.UI;
using System;

[RequireComponent(typeof(Text))]
public class HighScoreUpdate : MonoBehaviour
{
    private const string HIGH_SCORE_KEY = "HighScore";
    private Text highScoreText;

    private void Start()
    {
        highScoreText = GetComponent<Text>();
        UpdateHighScoreText();
    }

    private void UpdateHighScoreText()
    {
        float highScore = PlayerPrefs.GetInt(HIGH_SCORE_KEY, 0);
        TimeSpan highScoreTimeSpan = TimeSpan.FromSeconds(highScore);
        highScoreText.text = highScoreTimeSpan.ToString("mm':'ss");
    }
}
