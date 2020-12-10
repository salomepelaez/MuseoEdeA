using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FirelightsBugs : MonoBehaviour
{
    Manager manager;

    public GameObject firelights;
    public GameObject lights;
    public GameObject fireflyButton;

    bool isShinning = false;

    void Start()
    {
        manager = Manager.Instance;
        lights.SetActive(true);
        firelights.SetActive(false);
        fireflyButton.SetActive(false);
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Teleportation>() != null && manager.currentState == Manager.State.Walking)
        {
            fireflyButton.SetActive(true);
            manager.currentState = Manager.State.Watching;
            manager.displayPanel.SetActive(true);
            manager.displayText.text = manager.textArray[9];
            manager.infoImage.GetComponent<Image>().sprite = manager.displayImages[9];   
            manager.displayImage.GetComponent<Image>().sprite = manager.infoArray[9];
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.gameObject.GetComponent<Teleportation>() != null)
        {
            fireflyButton.SetActive(false);
        }
    }

    public void LightsManagement()
    {
        if(isShinning)
        {
            TurnOffLights();
        }

        if(!isShinning)
        {
            TurnOnLights();
        }
    }

    void TurnOffLights()
    {
        lights.SetActive(false);
        firelights.SetActive(true);
    }

    void TurnOnLights()
    {
        lights.SetActive(true);
        firelights.SetActive(false);
    }
}
