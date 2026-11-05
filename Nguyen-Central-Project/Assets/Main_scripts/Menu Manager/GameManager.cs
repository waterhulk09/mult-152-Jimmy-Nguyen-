using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("GM Settings")]
    public static GameManager Instance;
    public GameObject loseScreen;
      public GameObject pauseScreen;
    public GameObject winScreen;
     public Health playerHealth;

    bool isPaused;

    private void Awake()
    {
        Instance = this;
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.performed) TogglePause();
    }

    void TogglePause()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0f : 1f;
    }

    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            TogglePause();
        }

        pauseScreen.SetActive(isPaused);

        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            winScreen.SetActive(true);

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            Time.timeScale = 0f;
        }

        if (playerHealth.currentHealth <= 0)
        {
            loseScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void GameOver()
    {
        loseScreen.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Time.timeScale = 0f;
    }

    public void Restart()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}