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
        //displayCamera = manager.currentCamera;
        if(manager.playerControl == false)
        {
            //manager.normalCamera.SetActive(false);
            goBackPanel.SetActive(true);
            BlendCameras();
        }

        else if(manager.playerControl == true)
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
