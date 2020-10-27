using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayCamera : MonoBehaviour
{
    public int ID; 

    Manager manager;

    void Awake()
    {
        manager = Manager.Instance;        
    }

}
