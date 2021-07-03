using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ScoreManager : MonoBehaviour
{
    private float currentScore = 0;
    private Text scoreText;

    private TimeSpan timeSpan;

    private void Start()
    {
        scoreText = GetComponent<Text>();
    }

    private void Update()
    {
        currentScore += Time.deltaTime;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        timeSpan = TimeSpan.FromSeconds(currentScore);
        scoreText.text = timeSpan.ToString("mm':'ss");
    }

    public float GetScore()
    {
        return currentScore;
    }
}
