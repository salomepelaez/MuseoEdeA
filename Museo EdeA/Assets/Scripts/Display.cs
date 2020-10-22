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
        if(other.gameObject.GetComponent<PlayerMove>() != null)
        {
            manager.playerControl = false;
        }
    }
}
