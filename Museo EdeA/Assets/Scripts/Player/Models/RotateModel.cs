using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateModel : MonoBehaviour
{
    Manager manager;

    float speed = 50f;

    void Start()
    {
        manager = Manager.Instance;
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && manager.playerControl == false)
        {
            transform.Rotate(new Vector3(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0) * Time.deltaTime * speed);
        }
        
    }
}
