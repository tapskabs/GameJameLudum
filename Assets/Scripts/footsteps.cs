using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footsteps : MonoBehaviour
{
    public GameObject footstep;
    
    // Start is called before the first frame update
    void Start()
    {
        footstep.SetActive(false);
    }

    void footsteps_()
    {
        footstep.SetActive(true);
    }

    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            footsteps_();
        }



        if (Input.GetKeyDown("s"))
        {
            footsteps_();
        }

        if (Input.GetKeyDown("a"))
        {
            footsteps_();
        }

        if (Input.GetKeyDown("d"))
        {
            footsteps_();
        }

        if (Input.GetKeyUp("w"))
        {
            StopFootsteps();
        }


        if (Input.GetKeyUp("s"))
        {
            StopFootsteps();
        }

        if (Input.GetKeyUp("a"))
        {
            StopFootsteps();
        }

        if (Input.GetKeyUp("d"))
        {
            StopFootsteps();
        }

    }

  
    void StopFootsteps()
    {
        footstep.SetActive(false);
    }

  
}
