using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    private Animator anim;

    public void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
           anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);

        }
        
        if (Input.GetKey(KeyCode.Space))
        {
           anim.SetTrigger("jump"); 
        }
    }

}
