using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoryCardBehavior : MonoBehaviour
{
    public Sprite backImage;
    public Sprite frontImage;
    public Image image;
    public GameObject frontElement;

    private bool isFront;
    // Start is called before the first frame update
    void Start()
    {
        isFront = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void onClick()
    {
        if (isFront)
        {
            showBack();
        }
        else
        {
            showFront();
        }
        isFront = !isFront;
    }
    public void showFront()
    {
        image.sprite = frontImage;
    }
    public void showBack()
    {
        image.sprite = backImage;
    }
}
