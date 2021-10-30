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
    }

    // Update is called once per frame
    void Update()
    {
        base.update();
    }

    public override void renderButtons()
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

    public override void levelControllerOnIncorrectAnswer(){
        wordSignWordLevelController.onIncorrectAnswer();
    }
    public override void levelControllerOnCorrectAnswer(){
        wordSignWordLevelController.onCorrectAnswer();
    }
}
