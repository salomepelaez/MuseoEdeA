using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creator : MonoBehaviour
{
    Manager manager;

    Transform parent;

    int index;
    int currentIndex;
    int maxIndex = 20;

    float timeCounter = 2f;
    float timeBetweenWaves = 10f;
    float counter = 0;

    void Awake()
    {
        manager = Manager.Instance;

        parent = this.gameObject.transform;
    }

    private void Start()
    {
        currentIndex = 0;

        InvokeRepeating("Timer", 0f, 1f);
    }

    private void Update()
    {
        // El siguiente bloque de código es el que inicializa la creación de enemigos cuando el contador llega a 0. 
        if(timeCounter <= 0)
        {
            StartCoroutine(CreateWaves());
            timeCounter = timeBetweenWaves; // Luego, el primer contador pasa a tomar en cuenta el tiempo de espera asignado en el segundo contador.
        }

        timeCounter -= Time.deltaTime; // Esta línea es la encargada de disminuir estos contadores.                
    }

    IEnumerator CreateWaves()
    {
        if (currentIndex >= maxIndex)
            index = 0;
        else
            index = Random.Range(0, 4);

        for (int i = 0; i < index; i++)
        {
            Spawn();
            yield return new WaitForSeconds(1f); // Con diferencia de 1 segundo para que no se generen uno sobre el otro.
        }
    }
    
    public void Spawn()
    {
        currentIndex = currentIndex + index;
        Debug.Log(currentIndex);

        GameObject c = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Vector3 pos = parent.transform.position;
        c.AddComponent<Cockroach>();
  //      c.AddComponent<Rigidbody>();
//        c.GetComponent<Rigidbody>().freezeRotation = true;

        //c.GetComponent<Rigidbody>().useGravity = false;
        //c.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationY;
        c.transform.SetParent(parent);
        c.transform.position = pos; 
    }

    void Timer()
    {
        counter++;
    }
}
