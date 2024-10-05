using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
    public Text timerText;
    private Collider playerCollider;
    private void Update()
    {
        OnTriggerEnter(playerCollider);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            EventManager.OnTimerStop();
            timerText.color = Color.green;
            timerText.fontSize = 80;
        }
    }
}
