using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class OptionButtonBehaviour : MonoBehaviour
{
    public TestModalController testModalController;
    public Button button;
    public Image image;
    public Image correctImage; 
    public Image incorrectImage; 
    public Color correctColor;
    public Color incorrectColor;
    public bool isCorrect;
    // Start is called before the first frame update
    void Start()
    {
        correctImage.enabled = false;
        incorrectImage.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setAsCorrect()
    {
        isCorrect = true;
    }

    public void setAsIncorrect()
    {
        isCorrect = false;
    }

    public void onAnswer()
    {
        if (isCorrect)
        {
            correctImage.enabled = true;
            onCorrectAnswer();
        }
        else
        {
            incorrectImage.enabled = true;
            onIncorrectAnswer();
        }
    }

    public void onCorrectAnswer()
    {
        image.color = correctColor;

        testModalController.onCorrectAnswer();
    }

    public void onIncorrectAnswer()
    {
        image.color = incorrectColor;

        testModalController.onIncorrectAnswer();
    }

    public void showCorrectAnswer()
    {
        if (isCorrect) image.color = correctColor;
    }
}
