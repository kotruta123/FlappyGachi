using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(1);
        }
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }

    public void SettingsMenu()
    {
        SceneManager.LoadScene(2);
    }

    public void InfoMenu()
    {
        SceneManager.LoadScene(3);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}