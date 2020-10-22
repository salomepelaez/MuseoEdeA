using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager Instance;

    //public DisplayCamera dc;

    public bool playerControl;

    public Animation anim;

    public void Awake()
    {
        Instance = this;              
    }

    public void Start()
    {
        playerControl = true;
        anim = gameObject.GetComponent<Animation>();  
        //dc = gameObject.GetComponent<DisplayCamera>();
    }

    public void LeaveDisplay()
    {
        playerControl = true;
    }
}
