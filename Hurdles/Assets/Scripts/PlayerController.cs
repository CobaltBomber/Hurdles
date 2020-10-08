using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public bool raceStarted;
    public double time;
    public float tickTime;
    public Text timeText;
    public float speed;
    public double speedDouble;
    public bool penalty;
    public GameObject line;
    public GameObject addText;
    public GameObject playerText;
    public GameObject winLoss;
    public bool stop;
    public bool finished;
    public double finishTime;
    public Text playerTime;
    public Text loss;

    private Rigidbody finishLine;
    private Rigidbody player;
    private Animator animator;
    private Vector3 up;

    void Awake()
    {
        animator = GameObject.Find("Player").GetComponent<Animator>();
        
    }

    // Start is called before the first frame update
    void Start()
    {
        raceStarted = false;
        player = GetComponent<Rigidbody>();
        speed = 3;
        finishTime = 0;
        penalty = false;
        finished = false;
        finishLine = line.GetComponent<Rigidbody>();
        addText.SetActive(false);
        playerText.SetActive(false);
        winLoss.SetActive(false);
        up = transform.TransformDirection(Vector3.up);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey("e"))
        {
            raceStarted = true;
        }

        if (raceStarted == true)
        {
            
            tickTime += Time.deltaTime;

            animator.SetTrigger("crouchTrigger");

            if (tickTime >= 3.0 && finished == false)
            {
                animator.SetTrigger("startTrigger");
                player.velocity = new Vector3(speed, 0, 0);

                if (speed > 6)
                {
                    speed = speed - 1;
                }
                

                time += Time.deltaTime;
                if (penalty == true)
                {
                    time += 0.5;
                    penalty = false;
                    addText.SetActive(false);
                }

                int x = (int)(time * 100);
                float y = (float)x / 100.0f;
                timeText.text = y.ToString();

                if (Input.GetKey("space"))
                {
                    animator.SetTrigger("jumpTrigger");
                    player.AddForce(up * 2);
                }

                if (Input.GetKeyDown("w"))
                {
                    speed = speed + 1;
                    

                }

            }

            if (finishTime > 0)
            {
                animator.SetTrigger("idleTrigger");
                player.velocity = new Vector3(0, 0, 0);

                if (finishTime < 19.59)
                {
                    winLoss.SetActive(true);
                }

                if (finishTime > 19.59)
                {
                    loss.text = "You Lose!";
                    winLoss.GetComponent<Text>().text = loss.text;
                    winLoss.SetActive(true);
                }
            }
        }


    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Finishline") || other.gameObject.CompareTag("Stop"))
        {
            finished = true;
            finishLine.useGravity = true;
            finishLine.AddForce(transform.forward * 100);
            finishTime = time - 3;
            finishTime = Math.Round(finishTime, 2);
            string vOut = finishTime.ToString();
            playerTime.text = "Player Time: " + vOut;
            playerText.GetComponent<Text>().text = playerTime.text;
            playerText.SetActive(true);
        }

        if (other.gameObject.CompareTag("Hurdle"))
        {
            penalty = true;
            addText.SetActive(true);
        }


    }

}
