using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

namespace DefaultNamespace
{
    public class MenuGameManager : MonoBehaviour
    {
        public Button[] menuButtons;  // Assign your buttons in the Inspector
        private int selectedIndex = 0;
        private PlayerInputActions inputActions;

        private void Awake()
        {
            inputActions = new PlayerInputActions();
            inputActions.Menu.Navigate.performed += OnNavigate;
            inputActions.Menu.Confirm.performed += OnConfirm;
        }

        private void OnEnable()
        {
            inputActions.Menu.Enable();
            HighlightButton(selectedIndex);
        }

        private void OnDisable()
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

            if (selectedIndex < 0) selectedIndex = menuButtons.Length - 1;
            if (selectedIndex >= menuButtons.Length) selectedIndex = 0;

            HighlightButton(selectedIndex);
        }

        private void OnConfirm(InputAction.CallbackContext context)
        {
            menuButtons[selectedIndex].onClick.Invoke();
        }

        private void HighlightButton(int index)
        {
            for (int i = 0; i < menuButtons.Length; i++)
            {
                var colors = menuButtons[i].colors;
                colors.normalColor = (i == index) ? Color.yellow : Color.white; // Selected button turns yellow, others are white
                menuButtons[i].colors = colors;
            }
        }
    }
}