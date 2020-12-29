using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public bool InvertedMouse;
    
    float mouseX;
    float mouseY;
    float sensitivity = 40.0f; 
    float axisLimit = 0.0f; 

    void Update()
    {
        Rotate();
    }

    void Rotate()
    {
        mouseX += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        
        axisLimit = mouseY;

        if (InvertedMouse)
        {
            mouseY += Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        }

        else
        {
            mouseY -= Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        }

        if (axisLimit > 30.0f)
        {
            axisLimit = 30.0f;
            mouseY = 30.0f;
        }

        else if (axisLimit < -10.0f)
        {
            axisLimit = -10.0f;
            mouseY = -10.0f;
        }

        transform.eulerAngles = new Vector3(mouseY, mouseX, 0);
    }
}
