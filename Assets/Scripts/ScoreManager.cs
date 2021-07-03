using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ScoreManager : MonoBehaviour
{
    private float currentScore = 0;
    private Text scoreText;

    private bool gameOver = false;

    private TimeSpan timeSpan;

    [SerializeField]
    GameOverScoreUpdate gameOverScoreUpdate;

    private void Start()
    {
        scoreText = GetComponent<Text>();
    }

    private void Update()
    {
        if(!gameOver)
        {
            currentScore += Time.deltaTime;
            UpdateScoreText();
        }
    }

    private void UpdateScoreText()
    {
        timeSpan = TimeSpan.FromSeconds(currentScore);
        scoreText.text = timeSpan.ToString("mm':'ss");
    }

    public void FinishGame()
    {
        gameOver = true;
        gameOverScoreUpdate.UpdateScore(currentScore);
    }
}
