using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectSignWord : MonoBehaviour
{
    public Image signWordImage;
    public Sprite signWordSprite;
    // Start is called before the first frame update
    void Start()
    {
        renderSign();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setSprite(Sprite signWordSprite)
    {
        this.signWordSprite = signWordSprite;
        renderSign();
    }

    public void renderSign()
    {
        signWordImage.sprite = signWordSprite;
    }
}
