using System.Linq.Expressions;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    
    void Start()
    {
        // // Load the saved state of InvertY
        // InvertYToggle.isOn = PlayerPrefs.GetInt("InvertY", 0) == 1;

        // // Find the CameraController in the scene
        // cameraController = FindObjectOfType<CameraController>();

        // // Set the initial state of camera inversion
        // if (cameraController != null)
        // {
        //     cameraController.SetInvertY(InvertYToggle.isOn);
        // }
    }
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
