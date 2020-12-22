using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butterfly : MonoBehaviour
{
    Manager manager;

    void Start()
    {
        manager = Manager.Instance;
    }

    private void OnMouseDown()
    {
        Debug.Log(":D");
        this.gameObject.SetActive(false);

        manager.counter = manager.counter - 1;
        Debug.Log(manager.counter);

        if(manager.counter == 0)
        {
            Debug.Log(":(");
        }
    }

    
}
