using System;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    [SerializeField] private float timeToDisplay = 60.0f;

    private bool isRunning;

    private void Awake()
    {
        timerText = GetComponent<Text>();
    }

    private void OnEnable()
    {
        EventManager.TimerStart += EventManagerOnTimerStart;
        EventManager.TimerStop += EventManagerOnTimerStop;
        EventManager.TimerUpdate += EventManagerOnTimerUpdate;
    }
    
    private void OnDisable()
    {
        EventManager.TimerStart -= EventManagerOnTimerStart;
        EventManager.TimerStop -= EventManagerOnTimerStop;
        EventManager.TimerUpdate -= EventManagerOnTimerUpdate;
    }

    private void EventManagerOnTimerStart() => isRunning = true;
    private void EventManagerOnTimerStop() => isRunning = false;
    private void EventManagerOnTimerUpdate(float value) => timeToDisplay += value;

    // Update is called once per frame
    private void Update()
    {
        if(!isRunning) return;

        timeToDisplay += Time.deltaTime;

        TimeSpan timeSpan = TimeSpan.FromSeconds(timeToDisplay);
        timerText.text = timeSpan.ToString(format:@"mm\:ss\:ff");
    }
}
