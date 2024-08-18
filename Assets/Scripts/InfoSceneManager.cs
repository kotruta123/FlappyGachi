using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class InfoSceneManager : MonoBehaviour
{
    private PlayerInputActions inputActions;

    private void Awake()
    {
        inputActions = new PlayerInputActions();
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

    private void GoBackToMainMenu()
    {
        SceneManager.LoadScene(0); 
    }
}