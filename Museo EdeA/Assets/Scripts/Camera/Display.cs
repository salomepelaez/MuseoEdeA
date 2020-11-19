using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
        if(other.gameObject.GetComponent<Teleportation>() != null && manager.playerControl == true)
        {
            SwitchToDisplayCamera();
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if(other.gameObject.GetComponent<Teleportation>() && manager.playerControl == false)
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
            StopCoroutine("MoveModel");
            manager.model = null;
            manager.displayText.text = "";
        }
    }

    public void SwitchToDisplayCamera()
    {
        manager.playerControl = false;
        manager.currentCamera = this.gameObject.transform.GetChild(0).gameObject;
        manager.model = manager.displayArray[this.displayID];
        Debug.Log(manager.model);
        manager.displayText.text = manager.textArray[this.displayID];
        
    }

    IEnumerator MoveModel()
    {
        manager.model.transform.position += Vector3.up * _speed * Time.deltaTime;

        yield return new WaitForSeconds(2f);
    }

    /*public void GetID()
    {
        Cameras c;

        switch(c)
        {
            case c.Main:
            Debug.Log("a");
            break;

            case c.WallDisplay:
            Debug.Log("b");
            break;

            case c.SphereDisplay:
            _id = 2;
            manager.Cameras[2].gameObject.SetActive(true);
            break;

            case c.HexagonDisplay:
            _id = 2;
            manager.Cameras[2].gameObject.SetActive(true);
            break;

        }
    }

    public enum Cameras
    {
        Main,
        WallDisplay,
        SphereDisplay,
        HexagonDisplay
    }*/
}
