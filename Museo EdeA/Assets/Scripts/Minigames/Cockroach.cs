using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cockroach : MonoBehaviour
{
    Transform target;

    Vector3 direction;

    float npcSpeed = 5f;
    float rotationSpeed = 3f;
    float attackRange;

    void Start()
    {
        target = FindObjectOfType<Player>().GetComponent<Transform>();
    }

    void Update()
    {
        NPCMove();
    }

    public void NPCMove()
    {
        attackRange = Vector3.Distance(target.position, transform.position);

        if (attackRange < 5.0f)
        {
            direction = Vector3.Normalize(target.transform.position - transform.position);
            transform.position += direction * npcSpeed * Time.deltaTime;
        }      

        else
        {
            NPCAssignment();
        }          
    }

    public void NPCAssignment()
    {
        switch (Random.Range(0, 2))
        {
            case 0:
                transform.position += transform.forward * npcSpeed * Time.deltaTime;
                break;

            case 1:
                transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
                break;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Borde")
        {
            transform.rotation = Quaternion.Euler(0.0f, 180f, 0.0f);
        }
    }
}
