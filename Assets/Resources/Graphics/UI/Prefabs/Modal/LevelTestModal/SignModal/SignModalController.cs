using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignModalController : MonoBehaviour
{
    public Image signImage;
    public Sprite signSprite;
    // Start is called before the first frame update
    void Start()
    {
        setup();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setup()
    {
        signImage.sprite = signSprite;
    }
    public void OnButtonPressed()
    {
        Debug.Log("se presionó el botón");
    }
}
