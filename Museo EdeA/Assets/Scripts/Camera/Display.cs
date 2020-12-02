using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Display : MonoBehaviour
{
    public Manager manager;

    public int displayID; 

    private float _speed = 1f;
    
    public void Start()
    {
        manager = Manager.Instance;
        manager.model = null;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Teleportation>() != null && manager.currentState == Manager.State.Walking)
        {
            SwitchToDisplayCamera();
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if(other.gameObject.GetComponent<Teleportation>() && manager.currentState == Manager.State.Watching)
        {
            if(manager.model != null && manager.model.transform.position.y <= 5.05f)
            {
                StartCoroutine("MoveModel");
            }
        }

        else
        {
            manager.currentCamera = manager.normalCamera;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.gameObject.GetComponent<Teleportation>() != null)
        {
            manager.model.transform.position = manager.startPos;
            manager.model.transform.rotation = Quaternion.Euler(0, 0, 0);
            StopCoroutine("MoveModel");
            
            manager.model = null;
            manager.infoImage = null;
            manager.displayImage = null;
            manager.displayText.text = "";            
        }
    }

    public void SwitchToDisplayCamera()
    {
        manager.currentState = Manager.State.Watching;
        manager.currentCamera = this.gameObject.transform.GetChild(0).gameObject;
        manager.model = manager.displayArray[this.displayID];
        manager.startPos = manager.model.transform.position;
        Debug.Log(manager.startPos);
        Debug.Log(manager.model);

        manager.displayPanel.SetActive(true);
        manager.displayText.text = manager.textArray[this.displayID];
        manager.infoImage.GetComponent<Image>().sprite = manager.displayImages[this.displayID];   
        manager.displayImage.GetComponent<Image>().sprite = manager.infoArray[this.displayID];
    }

    IEnumerator MoveModel()
    {
        manager.model.transform.position += Vector3.up * _speed * Time.deltaTime;

        yield return new WaitForSeconds(2f);
    }

    public void Info()
    {
        manager.currentState = Manager.State.Reading;
        manager.displayPanel.SetActive(false);
        manager.infoPannel.SetActive(true);
    }
}
