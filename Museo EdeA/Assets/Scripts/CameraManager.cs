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
        /*switch(_id)
        {
            case 0:
            _id = 0;
            manager.Cameras[0].gameObject.SetActive(true);
            break;

            case 1:
            _id = 1;
            manager.Cameras[0].gameObject.SetActive(false);
            manager.Cameras[1].gameObject.SetActive(true);
            break;

            case 2:
            _id = 2;
            manager.Cameras[2].gameObject.SetActive(true);
            break;

        } */

        manager.currentCamera.SetActive(true);
    }
}
