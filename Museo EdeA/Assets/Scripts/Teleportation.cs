using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent mNavMeshAgent;

    void Start()
    {
        mNavMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }
    
    void Update()
    {
        ClickToMove();
    }

    void ClickToMove()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if(Input.GetMouseButtonDown(0))
        {
            if(Physics.Raycast(ray, out hit, 100))
            {
                mNavMeshAgent.destination = hit.point;
            }
        }
    }
}
