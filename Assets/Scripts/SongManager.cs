using UnityEngine;
using UnityEngine.SceneManagement;

public class SongManager : MonoBehaviour
{
    public static SongManager instance;
    
    [SerializeField] public AudioSource musicSource;
    [SerializeField] public AudioSource sfxSource;

    public AudioClip background;
    public AudioClip player;
    public AudioClip death;
    public AudioClip button;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0) 
        {
            if (musicSource.clip == null)
            {
                musicSource.clip = background;
                musicSource.loop = true; 
                musicSource.Play();
            }
        }

        // Load saved volume settings
        musicSource.volume = PlayerPrefs.GetFloat("MusicVolume", musicSource.volume);
        sfxSource.volume = PlayerPrefs.GetFloat("SFXVolume", sfxSource.volume);
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    public void PlayDeathSound()
    {
        PlaySFX(death);
    }
    

    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    public void SetSFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }
}