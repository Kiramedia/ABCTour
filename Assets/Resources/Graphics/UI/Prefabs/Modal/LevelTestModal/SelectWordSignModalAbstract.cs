using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class SelectWordSignModalAbstract : MonoBehaviour
{
    public GameObject buttonPrefab;
    public GameObject answerOptions;
    public WordButtonBehavior correctWordButtonBehavior;
    public List<GameObject> buttonsList;
    public float maxTime;
    public float currentTime;
    public bool isStartTime;
    public Image timeIcon;
    private bool timeFlag;

    // Start is called before the first frame update
    public void start()
    {
        currentTime = maxTime;

        timeFlag = true;

        isStartTime = true;
    }

    // Update is called once per frame
    public void update()
    {
        if (isStartTime && currentTime > 0)
        {
            currentTime -= Time.deltaTime;
        }
        else if (timeFlag && currentTime <= 0)
        {
            levelControllerOnIncorrectAnswer();
            timeFlag = false;
        }

        timeIcon.fillAmount = currentTime / maxTime;
    }

    public abstract void renderButtons();

    public void renderButton(SignWord signWord, bool isCorrect)
    {
        buttonPrefab.GetComponent<WordButtonBehavior>().selectWordSignModalAbstract = this;
        GameObject button = Instantiate(
            buttonPrefab,
            answerOptions.transform
        ) as GameObject;

        WordButtonBehavior optionButtonBehaviour = buttonPrefab.GetComponent<WordButtonBehavior>();

        button.GetComponent<SelectText>().setText(signWord.word);
        if (isCorrect)
        {
            button.GetComponent<WordButtonBehavior>().setAsCorrect();
            correctWordButtonBehavior = button.GetComponent<WordButtonBehavior>();
        }
        else
        {
            button.GetComponent<WordButtonBehavior>().setAsIncorrect();
        }

        buttonsList.Add(button);
    }

    public void onCorrectAnswer()
    {
        levelControllerOnCorrectAnswer();

        onAnswer();
    }

    public void onIncorrectAnswer()
    {
        levelControllerOnIncorrectAnswer();

        onAnswer();
    }

    public void onAnswer()
    {
        correctWordButtonBehavior.showCorrectAnswer();

        deactivateButtons();

        // timeBehaviour.isStartTime = false;
    }

    public void deactivateButtons()
    {
        buttonsList.ForEach(wordButton => wordButton.GetComponent<Button>().enabled = false);
    }

    public abstract void levelControllerOnIncorrectAnswer();
    public abstract void levelControllerOnCorrectAnswer();
}
