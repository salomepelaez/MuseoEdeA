using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdsCreator : MonoBehaviour
{
    CricketManager manager;

    public GameObject e;

    private void Start()
    {     
        manager = CricketManager.cricketInstance;
        InvokeRepeating("Create", 1f, 2f);                   
    }
    
    void Create()
    {
        if(manager.inGame == true)          
        {
            GameObject enemy = Instantiate(e, Vector3.zero, Quaternion.identity);
            enemy.AddComponent<Bird>();
            enemy.layer = 9;
            enemy.AddComponent<BoxCollider>();
            enemy.GetComponent<BoxCollider>().isTrigger = true;
            Vector3 pos = new Vector3();
            pos.x = Random.Range(-8f, 8f);
            pos.y = 6.5f;
            pos.z = 0f;

            enemy.transform.position = pos;
        }
    }
}
