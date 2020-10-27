using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Display : MonoBehaviour
{
    Manager manager;

    void Awake()
    {
        manager = Manager.Instance;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Teleportation>() != null)
        {
            manager.SelectCamera(manager.id);
        }
    }

    void SwitchToDisplayCamera()
    {
        manager.playerControl = false;
        //manager.currentCamera = manager.cameras(0);
        //manager.normalCamera.SetActive(false);
    }
}
