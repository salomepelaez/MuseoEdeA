using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Cricket : MonoBehaviour
{
    CricketManager manager;

    private Rigidbody2D rb;

    private Animator anim;

    public Vector2 jumpHeight;

    //private float jumpHeight = 40f;

    void Start()
    {
        manager = CricketManager.cricketInstance;
        anim = gameObject.GetComponent<Animator>();

        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Platforms>() != null)
        {
            anim.SetTrigger("jumpTrigger");
        }
    }
}
