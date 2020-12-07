using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCamera : MonoBehaviour
{
    Ray ray;    
    RaycastHit hit;

    Camera cam;

    void Start()
    {
        cam = transform.GetComponent<Camera>();
    }

    void FixedUpdate()
    {
        if(Input.GetMouseButton(0))
        {
            DeformMesh();
        }
    }

    void DeformMesh()
    {
        ray = cam.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit))
        {
            DeformPlane deform = hit.transform.GetComponent<DeformPlane>();

            deform.DeformThisPlane(hit.point);
        }
    }
}
