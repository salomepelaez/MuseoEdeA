using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GalleryView : MonoBehaviour
{
    public GameObject[] butterflies;
    public Button Right;
    public Button Left;
    public GameObject butterfly;
    public GameObject _button;

    private int i = 0;

    public void ActivateButtons()
    {
        _button.SetActive(true);
        butterfly.SetActive(true);
    }

    public void CloseButtons()
    {
        _button.SetActive(false);
    }

    public void Next()
    {
        if (i + 1 < butterflies.Length) {
            i++;
        }
    }

    public void Prev()
    {
        if (i > 0){
            i--;
        }
    }

    void Update()
    {
        butterfly = butterflies[i];
    }
}
