using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class SettingsManager : MonoBehaviour
{
    public Slider musicSlider;
    public Slider sfxSlider;
    private SongManager songManager;
    private PlayerInputActions inputActions;
    private bool isMusicSliderSelected = true; // Track which slider is selected

    private void Awake()
    {
        songManager = SongManager.instance;

        // Initialize sliders with current volume levels if available
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", songManager.musicSource.volume);
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", songManager.sfxSource.volume);

        inputActions = new PlayerInputActions();

        inputActions.Menu.Navigate.performed += OnNavigate;
        inputActions.Menu.Confirm.performed += ctx => ConfirmSelection();
        inputActions.Menu.Cancel.performed += ctx => GoBackToMainMenu();
    }

    private void OnEnable()
    {
        inputActions.Menu.Enable();
    }

    private void OnDisable()
    {
        inputActions.Menu.Disable();
    }

    private void Start()
    {
        // Add listeners to handle changes
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);

        HighlightSelectedSlider();
    }

    private void SetMusicVolume(float volume)
    {
        songManager.SetMusicVolume(volume);
        PlayerPrefs.SetFloat("MusicVolume", volume); // Save the music volume
    }

    private void SetSFXVolume(float volume)
    {
        songManager.SetSFXVolume(volume);
        PlayerPrefs.SetFloat("SFXVolume", volume); // Save the SFX volume
    }

    private void OnNavigate(InputAction.CallbackContext context)
    {
        Vector2 direction = context.ReadValue<Vector2>();

        if (direction.y > 0)
        {
            isMusicSliderSelected = true;
        }
        else if (direction.y < 0)
        {
            isMusicSliderSelected = false;
        }

        HighlightSelectedSlider();

        if (direction.x > 0)
        {
            AdjustVolume(0.1f); // Increase volume
        }
        else if (direction.x < 0)
        {
            AdjustVolume(-0.1f); // Decrease volume
        }
    }

    private void AdjustVolume(float change)
    {
        if (isMusicSliderSelected)
        {
            musicSlider.value = Mathf.Clamp(musicSlider.value + change, musicSlider.minValue, musicSlider.maxValue);
        }
        else
        {
            sfxSlider.value = Mathf.Clamp(sfxSlider.value + change, sfxSlider.minValue, sfxSlider.maxValue);
        }
    }

    private void HighlightSelectedSlider()
    {
        var musicColors = musicSlider.colors;
        var sfxColors = sfxSlider.colors;

        musicColors.normalColor = isMusicSliderSelected ? Color.yellow : Color.white;
        sfxColors.normalColor = isMusicSliderSelected ? Color.white : Color.yellow;

        musicSlider.colors = musicColors;
        sfxSlider.colors = sfxColors;
    }

    private void ConfirmSelection()
    {
        // If needed, you can trigger something when confirming the selection
    }

    private void GoBackToMainMenu()
    {
        SceneManager.LoadScene(0); // Load the main menu scene
    }
}
