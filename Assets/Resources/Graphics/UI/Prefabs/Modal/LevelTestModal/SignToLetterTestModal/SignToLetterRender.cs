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
        int randomNumber = random.Next(0, selectOptionsBehaviour.incorrectOptions.Count);

        int counter = 0;
        while (counter < selectOptionsBehaviour.incorrectOptions.Count)
        {
            if (randomNumber == counter)
            {
                renderButton(selectOptionsBehaviour.correctOption, true);
                randomNumber = selectOptionsBehaviour.incorrectOptions.Count + 1;
            }
            else
            {
                renderButton(selectOptionsBehaviour.incorrectOptions[counter], false);
                counter++;
            }
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

        UnityAction unityActionOnCorrectAnswer = new UnityAction(optionButtonBehaviour.onCorrectAnswer);
        UnityAction unityActionOnIncorrectAnswer = new UnityAction(optionButtonBehaviour.onIncorrectAnswer);

        button.GetComponent<RenderLetter>().letter = sign.letter;
        button.GetComponent<Button>().onClick.AddListener(
            isCorrect ?
            unityActionOnCorrectAnswer :
            unityActionOnIncorrectAnswer
        );
    }

    public void resizeComponent()
    {
        float componentWidth = 0;
        if (testModalController.level <= widthsByLevel.Count)
            componentWidth = widthsByLevel[testModalController.level - 1];

        this.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, componentWidth);
    }
}