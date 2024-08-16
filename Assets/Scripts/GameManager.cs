using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject loseWindow;
    public LoseWindow losesWindow;

    private void Start()
    {
        instance = this;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            RestartScene();
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            LoadMainMenu();
        }
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(1); // Load game scene number 1
        Time.timeScale = 1;
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0); // Load main menu scene number 0
        Time.timeScale = 1;
    }

    public void Lose()
    {
        loseWindow.SetActive(true);
        Time.timeScale = 0;
        losesWindow.DisplayScores(ScoreManager.Instances.score, ScoreManager.Instances.bestScore);
    }

    public void LoadScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
        Time.timeScale = 1;
    }
}