using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    CockroachManager manager;

    private int foodValue = 5;

    private Animator anim;

    void Start()
    {
        manager = CockroachManager.Instance;
        anim = GetComponent<Animator>();
        anim.SetBool("iddle", true);
    }

    void Update()
    {
        //anim.SetBool("iddle", true);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Player>() != null)
        {
            manager.pointsCounter = manager.pointsCounter + foodValue;
            this.anim.SetBool("iddle", false);
            StartCoroutine("DestroyFood");
        }
    }

    IEnumerator DestroyFood()
    {
        this.anim.SetBool("eaten", true);

        yield return new WaitForSeconds(1f);

        this.gameObject.SetActive(false);
    }
}
