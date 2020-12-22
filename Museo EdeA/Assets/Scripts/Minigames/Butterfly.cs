using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butterfly : ButterflyHaunt
{
    float speed = 10f;

    Vector3 direction;
    
    void Update()
    {
        TriangulatePosition();
    }

    private void OnMouseDown()
    {
        Debug.Log(":D");
        butterfliesList.Add(this.gameObject);
        this.gameObject.SetActive(false);
    }

    void TriangulatePosition()
    {
        Teleportation closest = null;

        float closestDistance = 5.0f;

        foreach(var player in FindObjectsOfType<Teleportation>())
        {
            float distance = Vector3.Distance(player.transform.position, transform.position);

            if (distance < closestDistance)
            {
                closest = player;
                closestDistance = distance;
                direction = Vector3.Normalize(player.transform.position - transform.position);
                transform.position -= direction * speed * Time.deltaTime;
            }
        }        
    }
}

