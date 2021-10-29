using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WordSignWordLevelController : MonoBehaviour
{
    public int level;
    public List<SignWord> availableWords;
    public SignWord correctSignWords;
    public List<SignWord> incorrectSignWords;
    public float maxTime;
    public float numberOfOptions;
    public bool isAnsweredCorrectly;
    public GameObject selectWordModal;
    public GameObject wordModal;

    // Start is called before the first frame update
    void Start()
    {
        selectTimeAndNumberOfOptions();
        selectOptions();
        selectWordModal.GetComponent<SelectWordModalController>().renderButtons();
        selectWordModal.GetComponent<SelectWordModalController>().maxTime = maxTime;
        wordModal.GetComponent<WordModalController>().setup();
        wordModal.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void selectTimeAndNumberOfOptions()
    {
        switch (level)
        {
            case 1:
                numberOfOptions = 3;
                maxTime = 120;
                break;
            case 2:
                numberOfOptions = 6;
                maxTime = 120;
                break;
            case 3:
                numberOfOptions = 6;
                maxTime = 60;
                break;

            default:
                numberOfOptions = 3;
                maxTime = 120;
                break;
        }
    }

    public void selectOptions()
    {
        List<SignWord> temporalAvailableWords = availableWords.ToList();

        System.Random random = new System.Random();
        int randomNumber = random.Next(0, temporalAvailableWords.Count);
        correctSignWords = RemoveAndGet(temporalAvailableWords, randomNumber);

        for (int i = 0; i < numberOfOptions - 1; i++)
        {
            random = new System.Random();
            randomNumber = random.Next(0, temporalAvailableWords.Count);
            incorrectSignWords.Add(RemoveAndGet(temporalAvailableWords, randomNumber));
        }
    }

    public T RemoveAndGet<T>(IList<T> list, int index)
    {
        lock (list)
        {
            T value = list[index];
            list.RemoveAt(index);
            return value;
        }
    }

    //when test answered correctly
    public void onCorrectAnswer()
    {
        // if(main != null){
        //     main.starsController.CorrectAnswer();
        // }

        isAnsweredCorrectly = true;
        onQuestionAnswered();

        // characterController.onCorrectAnswer();
    }

    //when test answered incorrectly
    public void onIncorrectAnswer()
    {
        // if(main != null){
        //     main.starsController.IncorrectAnswer();
        // }

        isAnsweredCorrectly = false;
        selectWordModal.GetComponent<SelectWordModalController>().onAnswer();
        onQuestionAnswered();

        // characterController.onIncorrectAnswer();
    }

    private void onQuestionAnswered()
    {
        onLevelFinish();
    }

    //when level finishes
    public void onLevelFinish()
    {
        Debug.Log("Kevin, haz lo tuyo");
        // Tutorial tutorialInfo = JsonUtility.FromJson<Tutorial>(PlayerPrefs.GetString("SelectedTutorial"));
        // if (!main.levelData.currentTrophies.Contains(tutorialInfo.id))
        // {
        //     main.levelData.currentTrophies.Add(tutorialInfo.id);
        // }

        // main.progressBar.AddSection(true);

        // if (numberOfMistakes > 0)
        // {

        //     if (!main.levelData.misstakesTrophies.Contains(tutorialInfo.id))
        //     {
        //         main.levelData.misstakesTrophies.Add(tutorialInfo.id);
        //     }
        //     Misstake.SetActive(true);
        // }
        // else
        // {
        //     Misstake.SetActive(false);
        // }

        // StartCoroutine(ChangeToPrincipal(main));
    }

    public void onWordModalButtonPressed(){
        selectWordModal.SetActive(true);
    }
}
