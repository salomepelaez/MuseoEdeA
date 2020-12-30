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

    public Transform player;

    public Display display;

    public GameObject normalCamera;
    public GameObject currentCamera;

    public GameObject model;
    
    public GameObject mouseSprite;
    public GameObject displayPanel;
    public GameObject infoPannel; 
    public GameObject tutorialImage;   

    public GameObject[] Cameras;
    public GameObject[] displayArray = new GameObject[7];

    public Sprite[] displayImages = new Sprite[0];
    public Sprite[] infoArray = new Sprite[0];

    public List<GameObject> butterfliesList = new List<GameObject>();

    public Image infoImage;
    public Image displayImage;

    public Vector3 startPos;
    
    public Text ensayo;

    private int selectedCameraIndex;
    public int counter;
    
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

        StartCoroutine("Tutorial");   
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

    IEnumerator Tutorial()
    {
        tutorialImage.SetActive(true);

        yield return new WaitForSeconds(10f);

        tutorialImage.SetActive(false);
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
