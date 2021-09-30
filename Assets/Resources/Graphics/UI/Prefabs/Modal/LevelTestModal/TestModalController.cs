using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestModalController : MonoBehaviour
{
    public SelectOptionsBehaviour selectOptionsBehaviour;
    public LevelTestModalRender levelTestModalRender;
    public int level;
    public int numberOfSimilarOptions;
    public OptionButtonBehaviour correctOptionButtonBehaviour;
    public List<GameObject> optionButtonsList;
    public LevelBehaviour levelBehaviour;
    // Start is called before the first frame update
    void Start()
    {
        selectOptionsBehaviour.setup();
        levelTestModalRender.setup();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void onCorrectAnswer()
    {
        levelBehaviour.onCorrectAnswer();

        onAnswer();
    }

    public void onIncorrectAnswer()
    {
        levelBehaviour.onIncorrectAnswer();

        onAnswer();
    }

    public void onAnswer()
    {
        correctOptionButtonBehaviour.showCorrectAnswer();

        deactivateButtons();
    }

    public void deactivateButtons()
    {
        optionButtonsList.ForEach(optionButton => optionButton.GetComponent<Button>().enabled = false);
    }
}
