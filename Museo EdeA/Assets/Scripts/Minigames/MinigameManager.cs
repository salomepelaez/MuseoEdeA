using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinigameManager : MonoBehaviour
{
    Manager manager;

    public GameObject miniGameButton;
    
    void Start()
    {
        miniGameButton.SetActive(false);
        manager = Manager.Instance;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Teleportation>() != null)
        {
            miniGameButton.SetActive(true);            
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.gameObject.GetComponent<Teleportation>() != null)
        {
            miniGameButton.SetActive(false);  
        }
    }
}
