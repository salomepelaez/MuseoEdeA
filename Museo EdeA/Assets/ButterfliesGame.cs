using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ButterfliesGame : MonoBehaviour
{
    Manager manager;

    //public GameObject butterflies;
    public GameObject butterfliesButton;

    bool isShinning = false;

    void Start()
    {
        manager = Manager.Instance;
        butterfliesButton.SetActive(false);
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Teleportation>() != null)
        {
            Debug.Log(".");

            manager.model = manager.displayArray[0];
            butterfliesButton.SetActive(true);
            manager.currentState = Manager.State.Watching;
            manager.displayPanel.SetActive(true);
            manager.displayText.text = manager.textArray[0];
            manager.infoImage.GetComponent<Image>().sprite = manager.displayImages[0];   
            manager.displayImage.GetComponent<Image>().sprite = manager.infoArray[0];
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.gameObject.GetComponent<Teleportation>() != null)
        {
            butterfliesButton.SetActive(false);
        }
    }

}
