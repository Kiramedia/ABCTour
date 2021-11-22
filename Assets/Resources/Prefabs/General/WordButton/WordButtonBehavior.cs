using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordButtonBehavior : MonoBehaviour
{
    public Button button;
    public Image image;
    public Image correctImage;
    public Image incorrectImage;
    public Color correctColor;
    public Color incorrectColor;
    public SelectWordSignModalAbstract selectWordSignModalAbstract;
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
            onCorrectAnswer();
        }
        else
        {
            onIncorrectAnswer();
        }
    }

    public void onCorrectAnswer()
    {
        correctImage.enabled = true;

        image.color = correctColor;

        selectWordSignModalAbstract.onCorrectAnswer();
    }

    public void onIncorrectAnswer()
    {
        incorrectImage.enabled = true;

        image.color = incorrectColor;

        selectWordSignModalAbstract.onIncorrectAnswer();
    }

    public void showCorrectAnswer()
    {
        if (isCorrect) image.color = correctColor;
    }
}
