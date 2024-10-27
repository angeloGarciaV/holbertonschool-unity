using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool isPaused = false;
    public GameObject pauseMenu;

    void Awake()
    {
        isPaused = false;
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Confined;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            Debug.Log("Pressed Escape");
            Cursor.lockState = CursorLockMode.None;
            Pause();
        }

        else if(Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            Resume();
            Cursor.lockState = CursorLockMode.Confined;
        }
    }

    public void Pause()
    {
        Debug.Log("Pause method called");
        isPaused = true;
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        Debug.Log("Pause menu activated");;
    }
    public void Resume()
    {
        Debug.Log("Resume method called");
        isPaused = false;
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        Debug.Log("Pause menu deactivated");
    }
    public void Options()
    {
        isPaused = false;
        SceneManager.LoadScene("Options");
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
