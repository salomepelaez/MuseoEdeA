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
        if(Input.mousePosition.x >= Screen.width - 1 || Input.mousePosition.y >= Screen.height - 1)
        {
            return;
        }

        else
        { 
            RotateCamera();
        }
    }

    void RotateCamera()
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

        if (axisLimit > 35.0f)
        {
            axisLimit = 35.0f;
            mouseY = 35.0f;
        }

        else if (axisLimit < -25.0f)
        {
            axisLimit = -25.0f;
            mouseY = -25.0f;
        }

        transform.eulerAngles = new Vector3(mouseY, mouseX, 0);
    }
}
