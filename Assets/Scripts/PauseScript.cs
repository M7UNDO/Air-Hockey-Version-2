using UnityEngine;
using UnityEngine.InputSystem;

public class PauseScript : MonoBehaviour
{
    private bool toggle;
    private PlayerInput playerInput;

    private System.Action<InputAction.CallbackContext> pauseAction;

    [Header("Pause UI Elements")]
    [Space(5)]
    [SerializeField] private GameObject pausePanel;

    private void OnEnable()
    {
        playerInput = new PlayerInput();
        playerInput.Player.Enable();

        pauseAction = ctx => Pause();
        playerInput.Player.Pause.performed += pauseAction;
    }

    private void OnDisable()
    {
        playerInput.Player.Pause.performed -= pauseAction;
        playerInput.Player.Disable();
    }

    public void Pause()
    {
        toggle = !toggle;

        if (toggle)
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1f;
        }

        print("Pause toggled: " + toggle);
    }
}
