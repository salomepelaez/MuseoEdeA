using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CricketManager : MonoBehaviour
{
    public static CricketManager cricketInstance;

    public bool inGame;

    void Awake()
    {
        cricketInstance = this;
    }
    
    void Start()
    {
        inGame = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
