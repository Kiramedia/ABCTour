using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectWordModalController : MonoBehaviour
{
    public WordSignWordLevelController wordSignWordLevelController;
    public GameObject wordButtonPrefab;
    public GameObject answerOptions;
    public WordSignWordLevelController levelController;
    public WordButtonBehavior correctWordButtonBehavior;
    public List<GameObject> wordButtonsList;
    public float maxTime;
    public float currentTime;
    public bool isStartTime;
    public Image timeIcon;
    private bool timeFlag;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = maxTime;

        timeFlag = true;

        isStartTime = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isStartTime && currentTime > 0)
        {
            currentTime -= Time.deltaTime;
        }
        else if (timeFlag && currentTime <= 0)
        {
            wordSignWordLevelController.onIncorrectAnswer();
            timeFlag = false;
        }

        timeIcon.fillAmount = currentTime / maxTime;
    }

    public void renderButtons()
    {
        System.Random random = new System.Random();
        int randomNumber = random.Next(0, wordSignWordLevelController.incorrectSignWords.Count + 1);

        List<SignWord> options = new List<SignWord>(wordSignWordLevelController.incorrectSignWords);
        options.Insert(randomNumber, wordSignWordLevelController.correctSignWords);

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

    public void renderButton(SignWord signWord, bool isCorrect)
    {
        wordButtonPrefab.GetComponent<WordButtonBehavior>().selectWordModalController = this;
        GameObject button = Instantiate(
            wordButtonPrefab,
            answerOptions.transform
        ) as GameObject;

        WordButtonBehavior optionButtonBehaviour = wordButtonPrefab.GetComponent<WordButtonBehavior>();

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

        wordButtonsList.Add(button);
    }

    public void onCorrectAnswer()
    {
        levelController.onCorrectAnswer();

        onAnswer();
    }

    public void onIncorrectAnswer()
    {
        levelController.onIncorrectAnswer();

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
        wordButtonsList.ForEach(wordButton => wordButton.GetComponent<Button>().enabled = false);
    }

}
