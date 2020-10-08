using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{

    public bool raceStarted;
    public float tickTime;
    public float speed;
    public GameObject AITime;
    public GameObject line;

    private Rigidbody finishLine;
    private Rigidbody ai;
    private Animator animator;
    // Start is called before the first frame update

    void Awake()
    {
        animator = GameObject.Find("AIRunner").GetComponent<Animator>();
        AITime.SetActive(false);
    }

    void Start()
    {
        raceStarted = false;
        ai = GetComponent<Rigidbody>();
        finishLine = line.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            raceStarted = true;
        }

        if (raceStarted == true)
        {
            tickTime += Time.deltaTime;

            if (tickTime >= 3.0)
            {
                if (tickTime < 23.0)
                {
                    animator.SetTrigger("startTrigger");
                    ai.velocity = new Vector3(speed, 0, 0);
                }

                if (tickTime > 23.0)
                {
                    animator.SetTrigger("idleTrigger");
                    ai.velocity = new Vector3(0, 0, 0);
                    AITime.SetActive(true);
                }
                
            }
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Jump"))
        {
            animator.SetTrigger("jumpTrigger");
           
        }

        if (other.gameObject.CompareTag("Stop"))
        {
            animator.SetTrigger("idleTrigger");
        }

        if (other.gameObject.CompareTag("Finishline"))
        {
            finishLine.useGravity = true;
            finishLine.AddForce(transform.forward * 100);
        }


    }

  


}
