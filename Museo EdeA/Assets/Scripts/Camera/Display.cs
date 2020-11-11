using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Display : MonoBehaviour
{
    public Manager manager;

    public int _id; 
    public int displayID;

    public GameObject model;

    private float speed = 1f;

    public void Start()
    {
        manager = Manager.Instance;
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
            if(model.transform.position.y <= 5.05f)
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
        }
    }

    public void SwitchToDisplayCamera()
    {
        manager.playerControl = false;
        manager.currentCamera = this.gameObject.transform.GetChild(0).gameObject;
        Debug.Log(manager.currentCamera);
        displayID = _id;
        Debug.Log("Display number " + displayID);
        //Debug.Log(currentCamera);
        //manager.Cameras[_id].enabled = true;
        //manager.Cameras[0].enabled = false;
        
    }

    IEnumerator MoveModel()
    {
        model.transform.position += Vector3.up * speed * Time.deltaTime;

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
