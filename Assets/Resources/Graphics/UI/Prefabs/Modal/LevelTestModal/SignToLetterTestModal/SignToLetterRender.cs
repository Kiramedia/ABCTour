using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignToLetterRender : MonoBehaviour
{
    public Image signImage;
    public SelectOptionsBehaviour selectOptionsBehaviour;
    public GameObject AnswerOptions;
    public GameObject optionButtonPrefab; 
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("render");
        signImage.sprite = selectOptionsBehaviour.correctOption.sign;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
