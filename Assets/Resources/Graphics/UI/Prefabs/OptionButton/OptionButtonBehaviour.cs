using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionButtonBehaviour : MonoBehaviour
{
    public TestModalController testModalController;
    public Button button;
    public Image incorrectImage; 
    public Image correctImage; 
    // Start is called before the first frame update
    void Awake()
    {
        incorrectImage.enabled = false;
        correctImage.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onCorrectAnswer(){
        correctImage.enabled = true;
        Debug.Log("on correct " + correctImage.enabled);

        testModalController.onCorrectAnswer();

    }

    public void onIncorrectAnswer(){
        incorrectImage.enabled = true;
        Debug.Log("on incorrect " + correctImage.enabled);

        testModalController.onIncorrectAnswer();
    }
}
