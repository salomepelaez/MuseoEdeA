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
        switch(manager.id)
        {
            case 0:
            Debug.Log("cero");
            break;

            case 1:
            Debug.Log("uno");
            break;

        }
    }
}
