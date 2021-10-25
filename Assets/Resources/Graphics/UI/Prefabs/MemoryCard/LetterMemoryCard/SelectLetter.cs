using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectLetter : MonoBehaviour
{
    public MemoryCardBehavior memoryCardBehavior;
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        char letter = char.ToLower(memoryCardBehavior.sign.letter);

        text.text = char.ToUpper(letter) + letter.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
