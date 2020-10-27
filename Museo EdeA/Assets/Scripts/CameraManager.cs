using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject displayCamera;
    public GameObject goBackPanel;

    Manager manager;

    void Start()
    {
        manager = Manager.Instance; 
        goBackPanel.SetActive(false);
    }

    void Update()
    {
        ChangePlayerCamera();
        BlendCameras();
    }
    
    public void ChangePlayerCamera()
    {
        //displayCamera = manager.currentCamera;
        if(manager.playerControl == false)
        {
            displayCamera.SetActive(true);
            //manager.normalCamera.SetActive(false);
            goBackPanel.SetActive(true);
        }

        else if(manager.playerControl == true)
        {
            //displayCamera.SetActive(false);
            goBackPanel.SetActive(false);
            //manager.normalCamera.SetActive(true);
            //manager.currentCamera = null;
        }
    }

    public void BlendCameras()
    {
        switch(manager.displayID)
        {
            case 0:
            manager.id = 0;
            break;

            case 1:
            manager.id = 1;
            break;

        }
    }
}
