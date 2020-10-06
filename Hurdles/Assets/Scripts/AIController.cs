using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{

    public bool raceStarted;
    public float tickTime;
    public float speed;

    private Rigidbody ai;
    private Animator animator;
    // Start is called before the first frame update

    void Awake()
    {
        animator = GameObject.Find("AIRunner").GetComponent<Animator>();
    }

    void Start()
    {
        raceStarted = false;
        ai = GetComponent<Rigidbody>();
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
                animator.SetTrigger("startTrigger");
                ai.velocity = new Vector3(speed, 0, 0);
            }
        }

    }
}
