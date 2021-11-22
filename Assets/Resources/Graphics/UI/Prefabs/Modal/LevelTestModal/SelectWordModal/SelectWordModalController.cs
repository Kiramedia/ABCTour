using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectWordModalController : SelectWordSignModalAbstract
{
    public WordSignWordLevelController wordSignWordLevelController;

    // Start is called before the first frame update
    void Start()
    {
        base.start();
        if(wordSignWordLevelController == null){
            GameObject levelController = GameObject.FindGameObjectWithTag("LevelController");
            if(levelController != null){
                wordSignWordLevelController = levelController.GetComponent<WordSignWordLevelController>();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        base.update();
    }

    public override void renderButtons()
    {
        if(wordSignWordLevelController == null){
            GameObject levelController = GameObject.FindGameObjectWithTag("LevelController");
            if(levelController != null){
                wordSignWordLevelController = levelController.GetComponent<WordSignWordLevelController>();
            }
        }

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

    private void renderButton(SignWord signWord, bool isCorrect)
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

    public override void levelControllerOnIncorrectAnswer(){
        wordSignWordLevelController.onIncorrectAnswer();
    }
    public override void levelControllerOnCorrectAnswer(){
        wordSignWordLevelController.onCorrectAnswer();
    }
}
