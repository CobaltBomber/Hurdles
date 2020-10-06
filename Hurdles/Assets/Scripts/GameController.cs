using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour 
{

    public bool raceStarted;
    // Start is called before the first frame update
    void Start()
    {
        raceStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            raceStarted = true;
        }
    }
}
