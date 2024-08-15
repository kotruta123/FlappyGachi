using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instances { get; set; }
    public int score { get; private set; }
    public int bestScore { get; private set; } 
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Start()
    {
        Instances = this;
        ResetCurrentScore();
    }

    public void setScore(int scoreIncrement)
    {
        score += scoreIncrement;
        if (score > bestScore)
        {
            bestScore = score;  
        }
        scoreText.text = "Score: " + score;
    }

    public void ResetCurrentScore()
    {
        score = 0;
        scoreText.text = "Score: " + score;
    }
}