using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Joystick joystick;

    private Vector3 direction;

    float speed = 5f;

    // Update is called once per frame
    void Update()
    {   
        Move();   
        LimitateAxis();     
    }

    private void Move() // Se creó una función para el movimiento, que luego es llamada en el Update.
    {
        direction = joystick.Direction * speed * Time.deltaTime;
        transform.position += new Vector3(direction.x, 0, direction.y);
    }

    private void LimitateAxis()
    {
        if(gameObject.transform.position.z >= 6f)
        {
            transform.position = new Vector3(transform.position.x, 2.16f, 6f);
        }

        if(gameObject.transform.position.z <= -7f)
        {
            transform.position = new Vector3(transform.position.x, 2.16f, -7f);
        }

        if(gameObject.transform.position.x >= 7f)
        {
            transform.position = new Vector3(7f, 2.16f, transform.position.z);
        }

        if(gameObject.transform.position.x <= -6f)
        {
            transform.position = new Vector3(-6f, 2.16f, transform.position.z);
        }
    }
}
