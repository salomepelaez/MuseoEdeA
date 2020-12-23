using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyHaunt : MonoBehaviour
{
    Manager manager;

    public GameObject butterfly1, butterfly2, butterfly3, butterfly4;

    Transform parent;

    void Start()
    {
        manager = Manager.Instance;

        parent = this.gameObject.transform;
        //Initialize();
    }

    public void Initialize()
    {
        int minGen = Random.Range(5, 15);
        manager.counter = minGen;
        Debug.Log(minGen);

        GameObject butterflyPrefab = new GameObject();

        for (int i = 0; i < minGen; i++) // Este For genera los objetos siguiendo los límites establecidos.
        {
            switch (Random.Range(0, 4))
            {
                case 0:
                butterflyPrefab = Instantiate(butterfly1, transform.position, Quaternion.identity);
                break;

                case 1:
                butterflyPrefab = Instantiate(butterfly2, transform.position, Quaternion.identity);
                break;

                case 2:
                butterflyPrefab = Instantiate(butterfly3, transform.position, Quaternion.identity);
                break;

                case 3:
                butterflyPrefab = Instantiate(butterfly4, transform.position, Quaternion.identity);
                break;
            }

            Vector3 pos = new Vector3();
            butterflyPrefab.AddComponent<Butterfly>();
            butterflyPrefab.transform.SetParent(parent);

            pos.x = Random.Range(-20, 40);
            pos.y = Random.Range(0.5f, 10);
            pos.z = Random.Range(2, -40);
            butterflyPrefab.transform.position = pos; 

            manager.butterfliesList.Add(butterflyPrefab);
        }
    }

    
}
