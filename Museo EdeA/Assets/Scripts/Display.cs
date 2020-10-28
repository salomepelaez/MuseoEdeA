using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Display : MonoBehaviour
{
    public Manager manager;

    public int _id; 

    public void Start()
    {
        manager = Manager.Instance;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Teleportation>() != null)
        {
            SwitchToDisplayCamera();
        }
    }

    public void SwitchToDisplayCamera()
    {
        manager.playerControl = false;
        manager.currentCamera = this.gameObject.transform.GetChild(0).gameObject;
        //Debug.Log(currentCamera);
        manager.Cameras[_id].enabled = true;
        manager.Cameras[0].enabled = false;
    }
}
