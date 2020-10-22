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
        displayCamera.SetActive(false);
        goBackPanel.SetActive(false);
    }

    void Update()
    {
        ChangePlayerCamera();
    }
    
    public void ChangePlayerCamera()
    {
        if(manager.playerControl == false)
        {
            displayCamera.SetActive(true);
            goBackPanel.SetActive(true);
        }

        else if(manager.playerControl == true)
        {
            displayCamera.SetActive(false);
            goBackPanel.SetActive(false);
        }
    }
}
