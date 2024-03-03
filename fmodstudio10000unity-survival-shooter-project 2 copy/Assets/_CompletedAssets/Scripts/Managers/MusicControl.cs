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
    public string morning = "event:/Atmos/Morning";
    public string dish = "event:/Atmos/Dish";
    

    FMOD.Studio.EventInstance MorningEv;
    FMOD.Studio.EventInstance AtmosEv;
    FMOD.Studio.EventInstance PadsEv;
    FMOD.Studio.EventInstance DrumsEv;
    FMOD.Studio.EventInstance DishEv;




    // Start is called before the first frame update
    void Start()
    {
        AtmosEv = FMODUnity.RuntimeManager.CreateInstance(atmos);
        PadsEv = FMODUnity.RuntimeManager.CreateInstance(pads);
        DrumsEv = FMODUnity.RuntimeManager.CreateInstance(drums);
        MorningEv = FMODUnity.RuntimeManager.CreateInstance(morning);
        DishEv = FMODUnity.RuntimeManager.CreateInstance(dish);

        AtmosEv.start();
        PadsEv.start();
        MorningEv.start();
        DishEv.start();
        DrumsEv.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("AtmosVol", 1);
        EventManager.OnTimerStart();



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

    public void PlayDrums()
    {
        DrumsEv.start();
        Debug.Log("playing drums");
    }
    public void StopDrums()
    {
        DrumsEv.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
    
    void Destroy()
    {

    }
    
}
