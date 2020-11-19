using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Manager : MonoBehaviour
{
    public static Manager Instance;

    public GameObject normalCamera;
    public GameObject currentCamera;
    public GameObject mouseSprite;

    public GameObject[] Cameras;
    public GameObject[] displayArray = new GameObject[7];

    public GameObject model;
    
    public bool playerControl;

    public TextMeshProUGUI displayText;
    public string[] textArray = new string[0];

    //public int id;
    //public int displayID;

    private int selectedCameraIndex;
    
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
