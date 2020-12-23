using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butterfly : MonoBehaviour
{
    Manager manager;

    float rotationSpeed = 50f;

    void Start()
    {
        manager = Manager.Instance;
    }

    void Update()
    {
        RotateButterfly();
    }

    private void OnMouseDown()
    {
        Debug.Log(":D");
        this.gameObject.SetActive(false);

        manager.counter = manager.counter - 1;
        Debug.Log(manager.counter);

        if(manager.counter == 0)
        {
            Debug.Log(":(");
        }
    }

    void RotateButterfly()
    {
        //Vector3 direction = Vector3.Normalize(manager.player.transform.position - transform.position);
        //this.gameObject.transform.rotation = Quaternion.EulerAngles(new Vector3(0, manager.player.transform.position.y, 0) *  rotationSpeed * Time.deltaTime);
        Vector3 direction = new Vector3(-1, 1, -1);
        Quaternion targetRotation = Quaternion.LookRotation(direction, manager.player.position - transform.position);
 
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

       //transform.Rotate(targetRotation);
    }
}
