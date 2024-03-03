using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class MinutesLeft : MonoBehaviour
{

    private TMP_Text minsText;
    private Animator animator;
    private Animation animation;
    public int timeLeft = 4;

    // Start is called before the first frame update
    void Awake()
    {
        minsText = GetComponent<TMP_Text>();
        animator = gameObject.GetComponent<Animator>();
        animation = gameObject.GetComponent<Animation>();
        //animator.Play("minutesLeft.Fade");
        animation.Play();

    }

    // Update is called once per frame
    void Update()
    {
        minsText.text = timeLeft + " Minutes Left";
    }
}
