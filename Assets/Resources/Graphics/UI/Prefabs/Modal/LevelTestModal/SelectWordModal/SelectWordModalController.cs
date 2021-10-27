using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectWordModalController : MonoBehaviour
{
    public WordSignWordLevelController wordSignWordLevelController;
    public GameObject wordButtonPrefab;
    public GameObject answerOptions;

    // Start is called before the first frame update
    void Start()
    {
        wordSignWordLevelController.selectTimeAndNumberOfOptions();
        wordSignWordLevelController.selectOptions();
        renderButtons();
        Debug.Log("SelectWordModalController");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void renderButtons()
    {
        System.Random random = new System.Random();
        int randomNumber = random.Next(0, wordSignWordLevelController.incorrectSignWords.Count + 1);

        List<SignWord> options = new List<SignWord>(wordSignWordLevelController.incorrectSignWords);
        options.Insert(randomNumber, wordSignWordLevelController.correctSignWords);

        Debug.Log(options.Count);
        options.ForEach((value) => {Debug.Log(value.word);});

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
        // wordButtonPrefab.GetComponent<WordButtonBehavior>().testModalController = testModalController;
        GameObject button = Instantiate(
            wordButtonPrefab,
            answerOptions.transform
        ) as GameObject;

        WordButtonBehavior optionButtonBehaviour = wordButtonPrefab.GetComponent<WordButtonBehavior>();

        Debug.Log(signWord.word + " ---------------");
        button.GetComponent<SelectText>().setText(signWord.word);
        if (isCorrect)
        {
            // button.GetComponent<OptionButtonBehaviour>().setAsCorrect();
            // testModalController.correctOptionButtonBehaviour = button.GetComponent<OptionButtonBehaviour>();
        }
        else
        {
            // button.GetComponent<OptionButtonBehaviour>().setAsIncorrect();
        }

        // testModalController.optionButtonsList.Add(button);
    }
}
