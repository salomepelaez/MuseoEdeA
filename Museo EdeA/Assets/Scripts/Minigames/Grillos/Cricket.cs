using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Cricket : MonoBehaviour
{
    CricketManager manager;

    public Joystick joystick;

    private float direction;
    private float speed = 3.0f;

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
        direction = joystick.Horizontal * speed * Time.deltaTime;
        transform.position += new Vector3(direction, 0f, 0f);

        if(direction < 0.01f)
        {
            transform.localScale= new Vector2(0.6f, 0.6f);
        }

        else if(direction > -0.01f)
        {
            transform.localScale= new Vector2(-0.6f, 0.6f);
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
