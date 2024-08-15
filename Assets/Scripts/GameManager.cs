using System.Collections;
using System.Collections.Generic;
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
        if (Input.GetKey(KeyCode.R) || Input.GetButtonDown("Cancel") || Input.GetButtonDown("ButtonNorth"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1;
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            LoadScene(1);
            Time.timeScale = 1;
        }
        if (Input.GetKeyDown(KeyCode.M)|| Input.GetButtonDown("ButtonEast"))
        {
            LoadScene(0);
        }
        if (Input.GetKeyDown(KeyCode.C)|| Input.GetButtonDown("ButtonWest"))
        {
            LoadScene(2);
        }if (Input.GetKeyDown(KeyCode.V)|| Input.GetButtonDown("LeftTriger"))
        {
            LoadScene(3);
        }
        
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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