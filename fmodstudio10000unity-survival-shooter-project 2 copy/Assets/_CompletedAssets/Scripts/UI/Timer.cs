using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class Timer : MonoBehaviour
{
    private TMP_Text timerText;

    [SerializeField] private float timeToDisplay = 300.0f;

    private bool isRunning;

    // Start is called before the first frame update
    private void Awake()
    {
        timerText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
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

    void Update()
    {
        if (!isRunning) return;
        if (timeToDisplay < 0.0f) return;
        timeToDisplay -= Time.deltaTime;

        TimeSpan t = TimeSpan.FromSeconds(timeToDisplay);
        timerText.text = t.ToString(@"mm\:ss\:ff");
    }
}