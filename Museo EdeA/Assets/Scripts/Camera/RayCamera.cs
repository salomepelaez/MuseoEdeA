using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCamera : MonoBehaviour
{
    Ray ray;    
    RaycastHit hit;

    Camera cam;

    [SerializeField]
    Transform ringPrefab;

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

            Instantiate(ringPrefab, new Vector3(hit.point.x, hit.point.y, hit.point.z + 0.3f), Quaternion.Euler(0,0,0));
        }
    }
}
