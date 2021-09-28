using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionButtonBehaviour : MonoBehaviour
{
    public TestModalController testModalController;
    public Button button;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onCorrectAnswer(){
        testModalController.onCorrectAnswer();
    }

    public void onIncorrectAnswer(){
        testModalController.onIncorrectAnswer();
    }
}
