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

    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public List<Pool> pools;

    public Dictionary<string, Queue<GameObject>> poolDictionary;

    void Start()
    {
        cam = transform.GetComponent<Camera>();

        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> ringPool = new Queue<GameObject>();

            for(int i = 0; i < pool.size; i++)
            {
                GameObject p = Instantiate(pool.prefab);
                p.SetActive(false);
                ringPool.Enqueue(p);
            }

            poolDictionary.Add(pool.tag, ringPool);
        }
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

            SpawnRings("Ring", new Vector3(hit.point.x, hit.point.y, hit.point.z + 0.11f), Quaternion.Euler(0,0,0));
        }
    }

    public GameObject SpawnRings(string tag, Vector3 position, Quaternion rotation)
    {
        GameObject ringToSpawn = poolDictionary[tag].Dequeue();
        ringToSpawn.SetActive(true);
        ringToSpawn.transform.tag = transform.tag;
        ringToSpawn.transform.position = position;
        ringToSpawn.transform.rotation = rotation;

        Transform[] allChildren = ringToSpawn.GetComponentsInChildren<Transform>();
        
        foreach (Transform child in allChildren)
        {
            child.gameObject.SetActive(true);
        }

        poolDictionary[tag].Enqueue(ringToSpawn);

        return ringToSpawn;
    }
}
