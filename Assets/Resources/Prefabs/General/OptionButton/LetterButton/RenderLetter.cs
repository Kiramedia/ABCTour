using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RenderLetter : MonoBehaviour
{
    public char letter;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        renderLetter();
    }

    public void renderLetter(){
        letter = char.ToLower(letter);

        text.text = char.ToUpper(letter) + letter.ToString();
    }

    public void setLetter(char letter){
        this.letter = letter;
        renderLetter();
    }
}
