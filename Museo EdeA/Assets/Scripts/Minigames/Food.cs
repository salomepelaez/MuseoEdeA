using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    CockroachManager manager;

    private int foodValue = 5;

    void Start()
    {
        manager = CockroachManager.Instance;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Player>() != null)
        {
            manager.pointsCounter = manager.pointsCounter + foodValue;
            this.gameObject.SetActive(false);
        }
    }
}
