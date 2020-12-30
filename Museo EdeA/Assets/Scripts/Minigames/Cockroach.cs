using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cockroach : MonoBehaviour
{
    CockroachManager manager;

    public State currentState = State.None;

    Transform target;

    Vector3 direction;
    Vector3 targetAngles;

    public float smooth = 1f;
    float npcSpeed = 5f;
    float rotationSpeed = 3f;
    float attackRange;

    void Start()
    {
        manager = CockroachManager.Instance;
        target = FindObjectOfType<Player>().GetComponent<Transform>();
        currentState = State.Moving;
    }

    void Update()
    {
        if(currentState == State.Moving)
            NPCMove();
    }

    public void NPCMove()
    {
        attackRange = Vector3.Distance(target.position, transform.position);

        if (attackRange < 3.0f)
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
                currentState = State.Moving;
                transform.position += transform.forward * npcSpeed * Time.deltaTime;
                break;

            case 1:
                currentState = State.Moving;
                transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
                break;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Player>() != null)
        {
            currentState = State.Attacking;
            manager.life = manager.life - 1;
            StartCoroutine("MadeDamage");
            Debug.Log(manager.life);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if(other.transform.tag == "Borde")
        {
            targetAngles = transform.eulerAngles + 180f * Vector3.up;
            transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, targetAngles, smooth * Time.deltaTime);
        }
    }

    IEnumerator MadeDamage()
    {
        yield return new WaitForSeconds(3f);
        direction = Vector3.Normalize(target.transform.position - transform.position);
        transform.position -= direction * npcSpeed * Time.deltaTime;

        yield return new WaitForSeconds(3f);

        currentState = State.Moving;
    }

    public enum State
    {
        None,
        Moving,
        Attacking
    }
}
