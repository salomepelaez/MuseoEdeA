using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateModel : Display
{
    float speed = 50f;

    void Update()
    {
        if (Input.GetMouseButton(0) && manager.currentState == Manager.State.Watching)
        {
            manager.model.transform.Rotate(new Vector3(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0) * Time.deltaTime * speed);
        }
        
    }
}
