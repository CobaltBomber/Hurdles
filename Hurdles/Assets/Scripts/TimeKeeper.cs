using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class TimeKeeper : MonoBehaviour
{
    public float time;
    public float tickTime;
    public Text timeText;
    public GameObject startText;
    public GameObject countDown;

    private Animator animator;
    private GameController hasRaceStarted;
    private bool raceStarted;

// Start is called before the first frame update

    void Awake()
    {
        animator = GameObject.Find("Countdown").GetComponent<Animator>();
    }

    void Start()
    {
        raceStarted = false;
        countDown.SetActive(false);
        
     }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            raceStarted = true;
            Destroy(startText);
            countDown.SetActive(true);
        }
        if (raceStarted == true)
        {
            animator.SetTrigger("countdownTrigger");

            tickTime += Time.deltaTime;
            
            if (tickTime >= 3.0)
            {
                time += Time.deltaTime;
                int x = (int)(time * 100);
                float y = (float)x / 100.0f;
                timeText.text = y.ToString();
            }
            
        }
        
    }
}
