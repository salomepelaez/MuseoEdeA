using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butterfly : ButterflyHaunt
{
    private void OnMouseDown()
    {
        Debug.Log(":D");
        butterfliesList.Add(this.gameObject);
        this.gameObject.SetActive(false);
    }
}

