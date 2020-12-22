using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyHaunt : MonoBehaviour
{
    public GameObject butterflyPrefab;

    void Start()
    {
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Initialize()
    {
        int minGen = Random.Range(5, 15);
        Debug.Log(minGen);

        for (int j = 0; j < minGen; j++) // Este For genera los objetos siguiendo los límites establecidos.
        {
            Vector3 pos = new Vector3();
            butterflyPrefab = GameObject.CreatePrimitive(PrimitiveType.Cube);
            butterflyPrefab.GetComponent<Renderer>().material.color = Color.yellow;

            pos.x = Random.Range(-20, 40);
            pos.y = Random.Range(0.5f, 10);
            pos.z = Random.Range(2, -40);
            butterflyPrefab.transform.position = pos; 
        }
    }
}
