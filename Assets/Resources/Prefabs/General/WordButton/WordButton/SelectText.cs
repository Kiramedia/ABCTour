using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectText : MonoBehaviour
{
    public Text upperCaseText;
    public Text lowerCaseText;
    public string text;
    // Start is called before the first frame update
    void Start()
    {
        renderText();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setText(string text){
        this.text = text;
        renderText();
    }

    public void renderText(){
        text = text.ToLower();

        upperCaseText.text = text.ToUpper();

        lowerCaseText.text = text;
    }
}
