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
        yield return new WaitForSeconds(2);
        Time.timeScale = 0f;
    }
}
