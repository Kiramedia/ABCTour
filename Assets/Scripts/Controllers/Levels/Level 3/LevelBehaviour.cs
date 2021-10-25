using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class LevelBehaviour : MonoBehaviour
{
    public int numberOfQuestions;
    // [NonSerialized]
    public int numberOfMistakes;
    // [NonSerialized]
    public int numberOfQuestionsAnswered;
    public int level;
    public float waitTime;
    public GameObject panel;
    public GameObject testModalPrefab;
    public CharacterController characterController;
    public List<Sign> usedSigns;
    private GameObject currentTestModal;
    public GameObject Trophy;
    public GameObject Misstake;

    private MainLevelController main;
    // Start is called before the first frame update
    void Start()
    {
        if(GameObject.FindGameObjectWithTag("LevelController") != null){
            main = GameObject.FindGameObjectWithTag("LevelController").GetComponent<MainLevelController>();
            level = PlayerPrefs.GetInt("selectedDifficult") + 1;
        }

        instantiateTestModal();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void instantiateTestModal()
    {
        StartCoroutine("instantiateNewTestModal");
    }

    //when test answered correctly
    public void onCorrectAnswer()
    {
        if(main != null){
            main.starsController.CorrectAnswer();
        }
        numberOfQuestionsAnswered++;

        onQuestionAnswered();

        characterController.onCorrectAnswer();
    }

    //when test answered incorrectly
    public void onIncorrectAnswer()
    {
        if(main != null){
            main.starsController.IncorrectAnswer();
        }
        numberOfMistakes++;
        numberOfQuestionsAnswered++;

        onQuestionAnswered();

        characterController.onIncorrectAnswer();
    }

    private void onQuestionAnswered()
    {
        if (numberOfQuestionsAnswered >= numberOfQuestions)
            onLevelFinish();
        else instantiateTestModal();
    }

    //when level finishes
    public void onLevelFinish()
    {
        Tutorial tutorialInfo = JsonUtility.FromJson<Tutorial>(PlayerPrefs.GetString("SelectedTutorial"));
        if (!main.levelData.currentTrophies.Contains(tutorialInfo.id))
        {
            main.levelData.currentTrophies.Add(tutorialInfo.id);
        }

        main.progressBar.AddSection(true);

        if (numberOfMistakes > 0)
        {

            if (!main.levelData.misstakesTrophies.Contains(tutorialInfo.id))
            {
                main.levelData.misstakesTrophies.Add(tutorialInfo.id);
            }
            Misstake.SetActive(true);
        }
        else
        {
            Misstake.SetActive(false);
        }

        StartCoroutine(ChangeToPrincipal(main));
    }

    IEnumerator instantiateNewTestModal()
    {
        yield return new WaitForSeconds(waitTime);

        Destroy(currentTestModal);

        testModalPrefab.GetComponent<TestModalController>().level = level;
        testModalPrefab.GetComponent<TestModalController>().levelBehaviour = this;
        testModalPrefab.GetComponent<SelectOptionsBehaviour>().levelBehaviour = this;

        currentTestModal = Instantiate(testModalPrefab, panel.transform) as GameObject;
    }

    /// <summary>
    /// Method to change scene to level principal 
    /// </summary>
    /// <param name="main">MainLevelController to save level data</param>
    /// <returns>Courutine</returns>
    IEnumerator ChangeToPrincipal(MainLevelController main)
    {
        SceneController sceneController = GameObject.FindGameObjectWithTag("Loader").GetComponent<SceneController>();
        yield return new WaitForSeconds(1f);

        panel.SetActive(false);
        Trophy.SetActive(true);

        yield return new WaitForSeconds(5f);

        main.SaveLevelData();
        sceneController.LoadScene("Level " + main.levelData.level.numberLevel);
    }
}
