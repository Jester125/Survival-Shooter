using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControl : MonoBehaviour
{




    //[FMODUnity.EventRef]
    public string music = "event:/Music/Music";
    public string breakBeat = "event:/Music/Break";

    FMOD.Studio.EventInstance musicEv;
    FMOD.Studio.EventInstance breakEv;




    // Start is called before the first frame update
    void Start()
    {
        musicEv = FMODUnity.RuntimeManager.CreateInstance(music);
        breakEv = FMODUnity.RuntimeManager.CreateInstance(breakBeat);

        musicEv.start();
        breakEv.start();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
