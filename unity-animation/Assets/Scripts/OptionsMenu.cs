using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public GameObject toggle;

    public void Back()
    {
        if(PlayerPrefs.GetString("CurrentScene") == null)
        {
            SceneManager.LoadScene(0);
        }else
        {
            SceneManager.LoadScene(PlayerPrefs.GetString("CurrentScene"));
        }
    }

    public void InvertY()
    {
        PlayerPrefs.GetInt("InvertY", toggle ? 1:0);
    }
    public void Apply()
    {
        PlayerPrefs.Save();
        Back();
    }

}
