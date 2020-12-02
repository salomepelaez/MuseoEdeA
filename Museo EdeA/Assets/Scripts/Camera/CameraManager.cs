using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : Display
{
    public GameObject displayCamera;
    public GameObject goBackPanel;

    public void Update()
    {
        ChangePlayerCamera();        
    }
    
    public void ChangePlayerCamera()
    {
        if(manager.currentState == Manager.State.Watching)
        {
            goBackPanel.SetActive(true);
            BlendCameras();
        }

        else if(manager.currentState == Manager.State.Reading)
        {
            goBackPanel.SetActive(false);
        }

        else if(manager.currentState == Manager.State.Walking)
        {
            goBackPanel.SetActive(false);
            manager.currentCamera = manager.normalCamera;
        }
    }

    public void BlendCameras()
    {
        manager.currentCamera.SetActive(true);
    }
}
