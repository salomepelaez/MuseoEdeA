using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public GameObject hA; 
    float speed = 2.5f; 

    Manager manager;

    void Awake()
    {
        manager = Manager.Instance;
    }

    void Update()
    {        
        if(manager.playerControl == true)
        {
            Move();
        } 

        float rotat = hA.transform.eulerAngles.y;
        transform.rotation = Quaternion.Euler(0.0f, rotat, 0.0f);
               
    }

    private void Move() 
    {
        if (Input.GetMouseButton(0))
        {
            transform.position += transform.forward * speed * Time.deltaTime; 
        }
    }
}
