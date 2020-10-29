using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager Instance;

    public GameObject normalCamera;
    public GameObject currentCamera;

    public Camera[] Cameras;
    public GameObject[] displayArray;
    //public Camera playerCamera, display1, display2;

    public bool playerControl;

    public int id;
    public int displayID;

    private int selectedCameraIndex;
    
    public void Awake()
    {
        Instance = this;   
        //cameras = new List<Camera>();    

        /*playerCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        display1 = GameObject.FindGameObjectWithTag("DisplayCamera1").GetComponent<Camera>();
        display2 = GameObject.FindGameObjectWithTag("DisplayCamera2").GetComponent<Camera>();
 
        cameras.Add(display1);   
        cameras.Add(display2);  */     
    }

    public void Start()
    {
        playerControl = true;
        currentCamera = normalCamera;

        for( int i = 0 ; i < Cameras.Length ; i++ )
        {
            id++;
            displayID++;
        }
        
        DisableCameras();
    }

    public void SelectCamera( int cameraIndex )
    {
        if( cameraIndex >= 0 && cameraIndex < Cameras.Length )
        {
            Cameras[selectedCameraIndex].enabled = false;
            selectedCameraIndex = cameraIndex;
            Cameras[selectedCameraIndex].enabled = true;
        }
    }

    public void DisableCameras()
    {
        for( int i = 0 ; i < Cameras.Length ; i++ )
            Cameras[i].gameObject.SetActive(false);

        Cameras[0].gameObject.SetActive(true);
    }

    public void LeaveDisplay()
    {
        playerControl = true;
        //currentCamera = null;
    }
}
