using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyHaunt : MonoBehaviour
{
    public List<GameObject> butterfliesList = new List<GameObject>();
    public GameObject butterflyPrefab;

    void Start()
    {
        int minGen = Random.Range(5, 15);
        Debug.Log(minGen);

        for (int i = 0; i < minGen; i++) // Este For genera los objetos siguiendo los límites establecidos.
        {
            Vector3 pos = new Vector3();
            butterflyPrefab = GameObject.CreatePrimitive(PrimitiveType.Cube);
            //butterflyPrefab.AddComponent<Butterfly>();
            butterflyPrefab.GetComponent<Renderer>().material.color = Color.yellow;

            pos.x = Random.Range(-20, 40);
            pos.y = Random.Range(0.5f, 10);
            pos.z = Random.Range(2, -40);
            butterflyPrefab.transform.position = pos; 
        }
    }
}
