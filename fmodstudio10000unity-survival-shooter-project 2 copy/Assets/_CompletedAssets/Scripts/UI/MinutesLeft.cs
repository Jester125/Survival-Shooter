using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class MinutesLeft : MonoBehaviour
{

    private TMP_Text timerText;
    private Animator anim;
    public int timeLeft = 0;

    // Start is called before the first frame update
    void Awake()
    {
        timerText = GetComponent<TMP_Text>();
        anim = gameObject.GetComponent<Animator>();
        anim.Play("minutesLeft.Fade", 0, 0.0f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
