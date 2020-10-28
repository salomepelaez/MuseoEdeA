using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayCamera : MonoBehaviour
{
    public Manager manager;

    

    public void Awake()
    {
        manager = Manager.Instance;        
    }

}
