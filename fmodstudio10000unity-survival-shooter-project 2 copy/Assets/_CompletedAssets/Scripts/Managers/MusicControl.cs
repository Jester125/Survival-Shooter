using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControl : MonoBehaviour
{


 
    //public PlayerHealth playerScript;


    //[FMODUnity.EventRef]
    public string atmos = "event:/Atmos/Atmos";
    public string pads = "event:/Music/Pads/Pads";
    public string drums = "event:/Music/Drums";


    FMOD.Studio.EventInstance AtmosEv;
    FMOD.Studio.EventInstance PadsEv;
    FMOD.Studio.EventInstance DrumsEv;




    // Start is called before the first frame update
    void Start()
    {
        AtmosEv = FMODUnity.RuntimeManager.CreateInstance(atmos);
        PadsEv = FMODUnity.RuntimeManager.CreateInstance(pads);
        DrumsEv = FMODUnity.RuntimeManager.CreateInstance(drums);

        AtmosEv.start();
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("AtmosVol", 1);
        StartCoroutine("FadeIn");

        

    }

    // Update is called once per frame
    void Update()
    {
        //if (playerScript.isDead == true)
        //{
        //    AtmosEv.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        //    PadsEv.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        //    DrumsEv.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        //}
    }

    IEnumerator FadeIn()
    {
       // yield return new WaitForSeconds(2);
        EventManager.OnTimerStart();
        yield return new WaitForSeconds(20);
        PadsEv.start();
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("PadsVol", 1);
        yield return new WaitForSeconds(20);
        DrumsEv.start();
    }
}
