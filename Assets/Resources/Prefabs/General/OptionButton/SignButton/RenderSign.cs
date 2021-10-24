using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RenderSign : MonoBehaviour
{
    public Sprite signSprite;
    public Image image;
    // Start is called before the first frame update
    void Start()
    {
        renderSign();
    }

    public void renderSign(){
        image.sprite = signSprite;
    }

    public void setSign(Sprite signSprite){
        this.signSprite = signSprite;
        renderSign();
    }
}
