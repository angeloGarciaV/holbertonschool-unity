using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool isPaused = false;
    public GameObject pauseMenu;
    public GameObject player;
    public Timer timer;
    public CinemachineFreeLook camInvert;

    private Vector3 playerPosition;
    private string currentTime;


    void Awake()
    {
        if(PlayerPrefs.GetInt("InvertY") == 0)
        {
            camInvert.m_YAxis.m_InvertInput = true;
        } else{
            camInvert.m_YAxis.m_InvertInput = false;
        }
        isPaused = false;
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Confined;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

    }

    public void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        Debug.Log("Pause method called");

        PlayerPrefs.SetString("CurrentTime", timer.timerText.text.ToString());
        PlayerPrefs.SetString("CurrentScene", SceneManager.GetActiveScene().name);

        playerPosition = GameObject.FindWithTag("Player").transform.position;
        PlayerPrefs.SetFloat("PlayerPosX", playerPosition.x);
        PlayerPrefs.SetFloat("PlayerPosY", playerPosition.y);
        PlayerPrefs.SetFloat("PlayerPosZ", playerPosition.z);

        PlayerPrefs.Save();
        
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        Debug.Log("Pause menu activated");;
    }

    public void Resume()
    {
        
        Cursor.lockState = CursorLockMode.Confined;
        Debug.Log("Resume method called");
        isPaused = false;

        timer.timerText.text = PlayerPrefs.GetString("CurrentTime");
        player.transform.position = playerPosition;

        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        Debug.Log("Pause menu deactivated");
    }
    public void Options()
    {
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
