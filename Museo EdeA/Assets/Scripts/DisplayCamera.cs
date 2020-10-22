using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayCamera : MonoBehaviour
{
    Manager manager;

    public Animation anim;

    void Awake()
    {
        manager = Manager.Instance;
        anim = gameObject.GetComponent<Animation>();
    }

    public void BlendCamera()
    {
        StartCoroutine("CameraTransition");
    }
    
    IEnumerator CameraTransition()
    {
        yield return new WaitForSeconds(1f);

        anim.Play("cameraTrans");
    }
}
