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

        bool isDone = manager.CheckBugsLeft();

        if(isDone == false)
        {
            Debug.Log(":(");
        }
    }

    
}
