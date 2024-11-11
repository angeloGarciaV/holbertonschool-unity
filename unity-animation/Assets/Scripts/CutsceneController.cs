using System.Collections;
using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    public GameObject mainCam;
    public GameObject cutSceneCam;
    public PlayerController playerController;
    public GameObject timer;

    void Start()
    {
        playerController.gameObject.SetActive(false);
        StartCoroutine(StartLevel());

    }

    IEnumerator StartLevel()
    {
        yield return new WaitForSeconds(3);
        playerController.gameObject.SetActive(true);
        timer.SetActive(true);
        mainCam.SetActive(true);
        cutSceneCam.SetActive(false);
    }
}
