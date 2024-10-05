using UnityEngine;

public class TimerTrigger : MonoBehaviour
{
    private Collider playerCollider;
    private void Update()
    {
        OnTriggerExit(playerCollider);
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            EventManager.OnTimerStart();
        }
    }
}
