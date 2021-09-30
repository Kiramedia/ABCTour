using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class SignToLetterRender : LevelTestModalRender
{
    public Image signImage;

    public override void setup()
    {
        signImage.sprite = selectOptionsBehaviour.correctOption.sign;

        setupAnswerOptionsLayout();

        renderButtons();

        resizeComponent();
    }

    public void setupAnswerOptionsLayout()
    {
        GridLayoutGroup gridLayoutGroup = answerOptions.GetComponent<GridLayoutGroup>();

        gridLayoutGroup.constraintCount = (testModalController.level < 2) ? 1 : 2;
    }

    public void renderButtons()
    {
        System.Random random = new System.Random();
        int randomNumber = random.Next(0, selectOptionsBehaviour.incorrectOptions.Count + 1);

        List<Sign> options = new List<Sign>(selectOptionsBehaviour.incorrectOptions);
        options.Insert(randomNumber, selectOptionsBehaviour.correctOption);

        int counter = 0;
        while (counter < options.Count)
        {
            if (randomNumber == counter)
            {
                renderButton(options[counter], true);
            }
            else
            {
                renderButton(options[counter], false);
            }
            counter++;
        }
    }

    public void renderButton(Sign sign, bool isCorrect)
    {
        optionButtonPrefab.GetComponent<OptionButtonBehaviour>().testModalController = testModalController;
        GameObject button = Instantiate(
            optionButtonPrefab,
            answerOptions.transform
        ) as GameObject;

        OptionButtonBehaviour optionButtonBehaviour = optionButtonPrefab.GetComponent<OptionButtonBehaviour>();

        button.GetComponent<RenderLetter>().letter = sign.letter;
        if (isCorrect)
        {
            button.GetComponent<OptionButtonBehaviour>().setAsCorrect();
            testModalController.correctOptionButtonBehaviour = button.GetComponent<OptionButtonBehaviour>();
        }
        else
        {
            button.GetComponent<OptionButtonBehaviour>().setAsIncorrect();
        }

        testModalController.optionButtonsList.Add(button);
    }

    public void resizeComponent()
    {
        float componentWidth = 0;
        if (testModalController.level <= widthsByLevel.Count)
            componentWidth = widthsByLevel[testModalController.level - 1];

        this.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, componentWidth);
    }
}