using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    public bool InvertedMouse;
    
    float mouseX;
    float mouseY;
    float sensitivity = 40.0f; 
    float axisLimit = 0.0f; 

    
    void Update()
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

        if (axisLimit > 90.0f)
        {
            axisLimit = 90.0f;
            mouseY = 90.0f;
        }

        else if (axisLimit < -90.0f)
        {
            axisLimit = -90.0f;
            mouseY = -90.0f;
        }

        transform.eulerAngles = new Vector3(mouseY, mouseX, 0);
    }
}
