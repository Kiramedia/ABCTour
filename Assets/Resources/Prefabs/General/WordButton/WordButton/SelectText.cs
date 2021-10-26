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
        text = text.ToLower();

        upperCaseText.text = text.ToUpper();

        lowerCaseText.text = text;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
