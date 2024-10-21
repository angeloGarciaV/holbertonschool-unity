using System.Linq.Expressions;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    public void Back()
    {
        int previousScene = PlayerPrefs.GetInt("PreviousScene", -1);
        if(previousScene != -1)
        {
            SceneManager.LoadScene(previousScene);
        }
        else
        {
            Debug.LogError("Previous scene not found in PlayerPrefs.");
        }
    }
}
