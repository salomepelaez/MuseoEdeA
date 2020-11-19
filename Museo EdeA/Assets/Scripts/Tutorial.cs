using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public Manager manager;

    private Animator anim;

    private bool watchedTutorial = false;
    
    public void Start()
    {
        manager = Manager.Instance;
        anim = gameObject.GetComponent<Animator>();
        //mouseSprite.SetActive(false);

        if(watchedTutorial == false)
            StartCoroutine("StartTutorial");
    }

    void Update()
    {

    }
    
    IEnumerator StartTutorial()
    {
        manager.mouseSprite.SetActive(true);
        anim.Play("rotationTutorial");

        yield return new WaitForSeconds(6f);

        manager.mouseSprite.SetActive(false);
    }
    
}
