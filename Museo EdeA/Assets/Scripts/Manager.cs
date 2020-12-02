using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public static Manager Instance;

    public enum Platform
    {
        Editor,
        Windows,
        AndroidMobile
    }

    public enum State
    {
        Walking,
        Watching,
        Reading
    }

    public Platform currentPlatform;
    public State currentState;

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
    
    public Text ensayo;
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
        currentState = State.Walking;
        currentCamera = normalCamera;

        displayPanel.SetActive(false);

        DisableCameras();       
    }

    public void PlatformInitializer()
    {
        if(Application.platform == RuntimePlatform.WindowsEditor)
        {
            currentPlatform = Platform.Editor;
            ensayo.text = "Editor";
        }

        if(Application.platform == RuntimePlatform.WindowsPlayer)
        {
            currentPlatform = Platform.Windows;
            ensayo.text = "Windows";
        }

        if(Application.platform == RuntimePlatform.Android)
        {
            currentPlatform = Platform.AndroidMobile;
            ensayo.text = "Android";
        }
    }

    public void DisableCameras()
    {
        for( int i = 0 ; i < Cameras.Length ; i++ )
            Cameras[i].SetActive(false);

        Cameras[0].SetActive(true);
    }

    public void LeaveDisplay()
    {
        currentState = State.Walking;
        DisableCameras();
        displayPanel.SetActive(false);
        infoPannel.SetActive(false);
    }

    public void MoreInfo()
    {
        display.Info();
    }

    public void CloseInfo()
    {
        currentState = Manager.State.Watching;
        infoPannel.SetActive(false);
        displayPanel.SetActive(true);
    }
}
