using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Sprites;

public class GalleryView : MonoBehaviour
{
    public Sprite[] butterflies;
    public Image butterfly;
    public Button Right;
    public Button Left;
    public GameObject _button;

    private int i = 0;

    void Start()
    {
        //butterfly.SetActive(false);
    }

    public void ActivateButtons()
    {
        _button.SetActive(true);
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
        butterfly.GetComponent<Image>().sprite = butterflies[i];
    }
}
