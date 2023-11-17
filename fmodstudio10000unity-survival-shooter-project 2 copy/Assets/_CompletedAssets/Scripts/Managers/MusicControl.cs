using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControl : MonoBehaviour
{




    //[FMODUnity.EventRef]
    public string music = "event:/Music/Music";

    FMOD.Studio.EventInstance musicEv;
    

    // Start is called before the first frame update
    void Start()
    {
        musicEv = FMODUnity.RuntimeManager.CreateInstance(music);

        musicEv.start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
