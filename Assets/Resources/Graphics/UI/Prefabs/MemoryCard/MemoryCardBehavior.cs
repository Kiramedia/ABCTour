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
    public Color color;
    public Sign sign;
    public bool isSelected;
    public bool isCompleted;

    public bool isFront;

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
    }
    public void showFront()
    {
        image.sprite = frontImage;
        image.color = color;
        frontElement.SetActive(true);

        isSelected = true;
        isFront = true;
    }
    public void showBack()
    {
        if (!isCompleted)
        {
            image.sprite = backImage;
            image.color = new Color32(255, 255, 255, 255);
            frontElement.SetActive(false);

            isSelected = false;
            isFront = false;
        }
    }
}
