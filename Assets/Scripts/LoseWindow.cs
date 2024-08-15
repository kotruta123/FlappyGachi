using System;
using TMPro;
using UnityEngine;

public class LoseWindow : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestScoreText;
    private SongManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindWithTag("AudioTag").GetComponent<SongManager>();
    }

    public void DisplayScores(int score, int bestScore)
    {
        scoreText.text = "Score: " + score.ToString();
        bestScore = PlayerPrefs.GetInt("BestScore", 0); // Retrieve the best score, default to 0 if not found
        if (score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetInt("BestScore", bestScore); // Save the new best score
        }
        bestScoreText.text = "Best Score: " + bestScore.ToString();

        // Play the death sound
        audioManager.PlayDeathSound();
    }
}