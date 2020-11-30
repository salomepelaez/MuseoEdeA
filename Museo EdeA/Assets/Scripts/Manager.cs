using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public static Manager Instance;

    public Display display;

    public GameObject normalCamera;
    public GameObject currentCamera;

    public GameObject model;
    
    public GameObject mouseSprite;
    public GameObject displayPanel;
    public GameObject infoPannel;    

    public GameObject[] Cameras;
    public GameObject[] displayArray = new GameObject[7];

    public Sprite[] displayImages = new Sprite[0];
    public Sprite[] infoArray = new Sprite[0];

    public Image infoImage;
    public Image displayImage;

    public Vector3 startPos;
    
    public bool playerControl;

    public TextMeshProUGUI displayText;
    public string[] textArray = new string[0];

    private int selectedCameraIndex;
    
    public void Awake()
    {
        Instance = this;     
    }

    public void Start()
    {
        display = GetComponent<Display>();
        playerControl = true;
        currentCamera = normalCamera;

        displayPanel.SetActive(false);

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
        displayPanel.SetActive(false);
        infoPannel.SetActive(false);
    }

    public void MoreInfo()
    {
        display.Info();
    }
}
