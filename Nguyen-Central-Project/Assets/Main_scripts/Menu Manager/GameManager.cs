using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("GM Settings")]
    public static GameManager Instance;
    public GameObject loseScreen;
    public SaveSystem saveSystem;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void GameOver()
    {
        if (loseScreen != null)
        {
            loseScreen.SetActive(true);
        }

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Time.timeScale = 0f;
    }

    public void Restart()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SaveGame()
    {
        if (saveSystem != null)
        {
            saveSystem.SaveGame();
        }
    }

    public void LoadGame()
    {
        if (saveSystem != null)
        {
            saveSystem.LoadGame();
        }
    }

    public void DeleteSave()
    {
        if (saveSystem != null)
        {
            saveSystem.DeleteSave();
        }
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}