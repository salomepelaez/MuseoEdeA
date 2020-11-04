using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkableFloor : MonoBehaviour
{
    public GameObject particles;

    void Start()
    {
        particles.SetActive(false);
    }

    void OnMouseEnter()
    {
        particles.SetActive(true);
    }

    void OnMouseOver()
    {
        ParticlesOnPoint();
    }

    void OnMouseExit()
    {
        particles.SetActive(false);
    }

    void ParticlesOnPoint()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100)) 
        {    
            //Vector3 newPos = new Vector3(hit.transform.position.x, 0.5f, hit.transform.position.y);
            particles.transform.position = hit.point;
            //particles.transform.position = newPos;
        }
    }
}
