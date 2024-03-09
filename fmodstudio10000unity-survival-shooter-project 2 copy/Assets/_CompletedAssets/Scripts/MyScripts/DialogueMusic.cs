using System.Collections;
using System.Collections.Generic;
using CompleteProject;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueMusic : MonoBehaviour
{
    public GameObject fadeEffect;
 
    public string MainScene = "";

    public string dialogue = "event:/Dialogue/Dialogue";
    public GameObject rabbit;


    FMOD.Studio.EventInstance DialogueEv;

    // Start is called before the first frame update
    void Start()
    {
        DialogueEv = FMODUnity.RuntimeManager.CreateInstance(dialogue);
        DialogueEv.start();
        StartCoroutine("WaitforLoad");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextScene()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Effects/Transition");
        rabbit.transform.Rotate (0f, 15f, 0f);
        fadeEffect.SetActive(true);
        StartCoroutine("Waitfor5");
    }

    IEnumerator Waitfor5()
    {
        yield return new WaitForSeconds(5);
        DialogueEv.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        SceneManager.LoadScene(MainScene);
    }

    public void FadeIn()
    {
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("DialogueVol", 1);
        Time.timeScale = 1f;

    }

    IEnumerator WaitforLoad()
    {
        yield return new WaitForSeconds(3f); 
        Time.timeScale = 0f;
    }

    public void PlayLine(int line)
    {
        if (line == 1)
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/Dialogue/Lines/Line1");
        }
        if (line == 2)
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/Dialogue/Lines/Line2");
        }
        if (line == 3)
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/Dialogue/Lines/Line3");
        }
        if (line == 4)
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/Dialogue/Lines/Line4");
        }
        if (line == 5)
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/Dialogue/Lines/Line5");
        }
        if (line == 6)
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/Dialogue/Lines/Line6");
        }
        if (line == 7)
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/Dialogue/Lines/Line7");
        }
        
    }
}
