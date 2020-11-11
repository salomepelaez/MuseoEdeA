using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager Instance;

    public GameObject normalCamera;
    public GameObject currentCamera;

    public GameObject[] Cameras;
    public GameObject[] displayArray;

    public bool playerControl;

    //public int id;
    //public int displayID;

    //private int selectedCameraIndex;
    
    public void Awake()
    {
        Instance = this;     
    }

    public void Start()
    {
        playerControl = true;
        currentCamera = normalCamera;
        
        DisableCameras();
    }

    public void DisableCameras()
    {
        for( int i = 0 ; i < Cameras.Length ; i++ )
            Cameras[i].SetActive(false);

        Cameras[0].SetActive(true);
    }

    public void LeaveDisplay()
    {
        playerControl = true;
        DisableCameras();
    }
}
