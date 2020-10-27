using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager Instance;

    public GameObject normalCamera;
    //public GameObject currentCamera;

    public List<Camera> cameras;
    public Camera playerCamera, display1, display2;

    public bool playerControl;

    public int id;
    
    public void Awake()
    {
        Instance = this;   
        cameras = new List<Camera>();    

        playerCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        display1 = GameObject.FindGameObjectWithTag("DisplayCamera1").GetComponent<Camera>();
        display2 = GameObject.FindGameObjectWithTag("DisplayCamera2").GetComponent<Camera>();
 
        cameras.Add(playerCamera);
        cameras.Add(display1);   
        cameras.Add(display2);       
    }

    public void Start()
    {
        playerControl = true;
        
        foreach (Camera c in cameras)
        {
            id++;
        }
    }

    public void LeaveDisplay()
    {
        playerControl = true;
        //currentCamera = null;
    }
}
