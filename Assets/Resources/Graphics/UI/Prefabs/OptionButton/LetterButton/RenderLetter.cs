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
        letter = char.ToLower(letter);

        text.text = char.ToUpper(letter) + letter.ToString();
    }
}
