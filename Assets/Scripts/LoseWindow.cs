using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class LoseWindow : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestScoreText;
    public Button restartButton;
    public Button mainMenuButton;

    private SongManager audioManager;
    private PlayerInputActions inputActions;
    private int selectedIndex = 0; // To track the selected button

    private void Awake()
    {
        audioManager = GameObject.FindWithTag("AudioTag").GetComponent<SongManager>();

        inputActions = new PlayerInputActions();

        inputActions.Menu.Navigate.performed += OnNavigate;
        inputActions.Menu.Confirm.performed += OnConfirm;
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

        // Enable input actions for the menu
        EnableMenuActions();
    }

    private void EnableMenuActions()
    {
        inputActions.Menu.Enable();
        HighlightButton(selectedIndex);
    }

    private void DisableMenuActions()
    {
        inputActions.Menu.Disable();
    }

    private void OnNavigate(InputAction.CallbackContext context)
    {
        Vector2 direction = context.ReadValue<Vector2>();

        if (direction.y > 0)
        {
            selectedIndex--;
        }
        else if (direction.y < 0)
        {
            selectedIndex++;
        }

        selectedIndex = Mathf.Clamp(selectedIndex, 0, 1); // We only have 2 buttons (Restart and Main Menu)

        HighlightButton(selectedIndex);
    }

    private void OnConfirm(InputAction.CallbackContext context)
    {
        if (selectedIndex == 0)
        {
            RestartScene(); // Restart the game
        }
        else if (selectedIndex == 1)
        {
            LoadMainMenu(); // Go to main menu
        }
    }

    private void HighlightButton(int index)
    {
        // Reset button colors to normal
        restartButton.GetComponent<Image>().color = Color.white;
        mainMenuButton.GetComponent<Image>().color = Color.white;

        // Highlight the selected button
        if (index == 0)
        {
            restartButton.GetComponent<Image>().color = Color.yellow;
        }
        else if (index == 1)
        {
            mainMenuButton.GetComponent<Image>().color = Color.yellow;
        }
    }

    private void RestartScene()
    {
        DisableMenuActions(); // Disable input before changing the scene
        SceneManager.LoadScene(1); // Load game scene number 1
        Time.timeScale = 1;
    }

    private void LoadMainMenu()
    {
        DisableMenuActions(); // Disable input before changing the scene
        SceneManager.LoadScene(0); // Load main menu scene number 0
        Time.timeScale = 1;
    }
}
