using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void LevelSelect(int level)
    {
        PlayerPrefs.SetInt("PreviousScene", SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.Save();
        SceneManager.LoadScene(level);

    }

    public void Options()
    {
        PlayerPrefs.SetInt("PreviousScene", SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.Save();
        SceneManager.LoadScene(1);
    }
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Exited");
    }
}
