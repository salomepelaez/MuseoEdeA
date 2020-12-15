using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingScript : MonoBehaviour, IPooledObject
{
    public void OnObjectSpawn()
    {
        Debug.Log("wiii");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "RingCollider")
        {
            other.gameObject.SetActive(false);

            Transform[] allChildren = other.GetComponentsInChildren<Transform>();
        
            foreach (Transform child in allChildren)
            {
                child.gameObject.SetActive(false);
            }  
        }

              
    }
}
