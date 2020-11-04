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
            particles.transform.position = hit.point;
        }
    }
}
