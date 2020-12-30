using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Display : MonoBehaviour
{
    public Manager manager;

    public int displayID; 
    
    public void Start()
    {
        manager = Manager.Instance;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Teleportation>() != null && manager.currentState == Manager.State.Walking)
        {
            SwitchToDisplayCamera();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        manager.infoImage.GetComponent<Image>().sprite = null;   
        manager.displayImage.GetComponent<Image>().sprite = null; 

        manager.currentState = Manager.State.Walking;
    }

    public void SwitchToDisplayCamera()
    {
        //manager.model = manager.displayArray[this.displayID];
        manager.currentState = Manager.State.Watching;
        manager.currentCamera = this.gameObject.transform.GetChild(0).gameObject;

        manager.displayPanel.SetActive(true);
        manager.infoImage.GetComponent<Image>().sprite = manager.displayImages[this.displayID];   
        manager.displayImage.GetComponent<Image>().sprite = manager.infoArray[this.displayID];
    }

    public void Info()
    {
        manager.currentState = Manager.State.Reading;
        manager.displayPanel.SetActive(false);
        manager.infoPannel.SetActive(true);
    }
}
