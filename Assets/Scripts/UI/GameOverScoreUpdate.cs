using System;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScoreUpdate : MonoBehaviour
{
    [SerializeField]
    private Text currentScoreText;

    [SerializeField]
    private Text highScoreText;

    private const string HIGH_SCORE_KEY = "HighScore";

    public void UpdateScore(float score)
    {
        int highScore = PlayerPrefs.GetInt(HIGH_SCORE_KEY, 0);

        if (Mathf.FloorToInt(score) > highScore)
        {
            highScoreText.text = "New high score!";
            PlayerPrefs.SetInt(HIGH_SCORE_KEY, Mathf.FloorToInt(score));
        }
        else
        {
            TimeSpan highScoreTimeSpan = TimeSpan.FromSeconds(highScore);
            highScoreText.text = highScoreTimeSpan.ToString("mm':'ss");
        }

        TimeSpan scoreTimeSpan = TimeSpan.FromSeconds(score);
        currentScoreText.text = scoreTimeSpan.ToString("mm':'ss");
    }
}
