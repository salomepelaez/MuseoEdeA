using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cricket : MonoBehaviour
{
    CricketManager manager;

    private Animator anim;

    void Start()
    {
        manager = CricketManager.cricketInstance;
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("isJumping", true);
        }
    }
}
