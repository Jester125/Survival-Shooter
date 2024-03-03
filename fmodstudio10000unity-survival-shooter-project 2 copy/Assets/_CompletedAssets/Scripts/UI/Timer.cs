using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using CompleteProject;

public class Timer : MonoBehaviour
{
    private TMP_Text timerText;
    public MinutesLeft minsLeft;
    public GameObject minsDisplay;
    public GameObject survived;
    public MusicControl musicScript;
    public daylight daylightScript;
    public SpawnManager spawnManager;
    private bool secsLeft = false;
    public GameObject fadeEffect;
    public bool isFinished = false;
    public GameObject restartButton;

    
    

    [SerializeField] private float timeToDisplay = 240.0f;

    private bool isRunning = true;

    // Start is called before the first frame update
    private void Awake()
    {
        timerText = GetComponent<TMP_Text>();
        minsLeft.timeLeft = 4;
        StartCoroutine("Waitfor8");
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Morning", 0);
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("BreakFade", 0);

        spawnManager.BearSpawnTime = 6f;
        spawnManager.BunnySpawnTime = 8f;
        spawnManager.HelleSpawnTime = 40f;

        
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
        if (timeToDisplay <= 180.0f && minsLeft.timeLeft == 4)
        {
            minsLeft.timeLeft = 3;
            StartCoroutine("Waitfor8");
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("PadsVol", 1);
            
            spawnManager.BearSpawnTime = 4f;
            spawnManager.BunnySpawnTime = 5f;
            spawnManager.HelleSpawnTime = 30f;
            spawnManager.Respawn();

        }
        if (timeToDisplay <= 120.0f && minsLeft.timeLeft == 3)
        {
            minsLeft.timeLeft = 2;
            StartCoroutine("Waitfor8");
            musicScript.PlayDrums();
            spawnManager.BearSpawnTime = 3f;
            spawnManager.BunnySpawnTime = 2f;
            spawnManager.HelleSpawnTime = 20f;
            spawnManager.Respawn();
        }
        if (timeToDisplay <= 60.0f && minsLeft.timeLeft == 2)
        {
            minsLeft.timeLeft = 1;
            StartCoroutine("Waitfor8");
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Morning", 1);
            spawnManager.BearSpawnTime = 1f;
            spawnManager.BunnySpawnTime = 2f;
            spawnManager.HelleSpawnTime = 10f;
            spawnManager.Respawn();
        }
        if (timeToDisplay <= 30.0 && secsLeft == false)
        {
            secsLeft = true;
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("AtmosVol", 0);
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Padsvol", 0);
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("BreakFade", 1);
            daylightScript.FadeLight();
        }

        if (timeToDisplay <= 0.0f && isFinished == false)
        {
            isFinished = true;
            StartCoroutine("Ending");
            
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Morning", 0);
        };
        timeToDisplay -= Time.deltaTime;

        TimeSpan t = TimeSpan.FromSeconds(timeToDisplay);
        
        timerText.text = t.ToString(@"mm\:ss\:ff");

       
    }

    IEnumerator Waitfor8()
    {
        minsDisplay.SetActive(true);
        FMODUnity.RuntimeManager.PlayOneShot("event:/Effects/ClockChimes");
        yield return new WaitForSeconds(8);
        minsDisplay.SetActive(false);

        
    }
    IEnumerator Ending()
    {
        isRunning = false;
        FMODUnity.RuntimeManager.PlayOneShot("event:/Effects/ClockChimes");
        musicScript.StopDrums();
        survived.SetActive(true);
        Time.timeScale = 0.3f;
        fadeEffect.SetActive(true);
        yield return new WaitForSeconds(3);
        //survived.SetActive(false);
        Time.timeScale = 0;
        restartButton.SetActive(true);
        




    }
}

