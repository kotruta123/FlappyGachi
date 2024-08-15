using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public Slider musicSlider;
    public Slider sfxSlider;
    private SongManager songManager;

    private void Awake()
    {
        songManager = SongManager.instance;

        // Initialize sliders with current volume levels if available
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", songManager.musicSource.volume);
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", songManager.sfxSource.volume);
    }

    private void Start()
    {
        // Add listeners to handle changes
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
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
}