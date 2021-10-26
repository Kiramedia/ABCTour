using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryLevelBehaviour : MonoBehaviour
{
    // [NonSerialized]
    private int numberOfMistakes = 0;
    // [NonSerialized]
    public int level;
    public float waitTime;
    public CharacterController characterController;
    private int numberOfCorrect = 0;

    private MainLevelController main;

    public GameObject panel;
    public GameObject Trophy;
    public GameObject Misstake;

    private bool levelIsFinish = false;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        if(GameObject.FindGameObjectWithTag("LevelController") != null){
            main = GameObject.FindGameObjectWithTag("LevelController").GetComponent<MainLevelController>();
            level = PlayerPrefs.GetInt("selectedDifficult") + 1;
        }
    }

    //when test answered correctly
    public void onCorrectAnswer()
    {
        if(main != null){
            main.starsController.CorrectAnswer();
        }
        numberOfCorrect++;
        characterController.onCorrectAnswer();
    }

    //when test answered incorrectly
    public void onIncorrectAnswer()
    {
        characterController.onIncorrectAnswer();
    }

    //when level finishes
    public void onLevelWon()
    {
        if(!levelIsFinish){
            characterController.onCorrectAnswer();
            onLevelFinish();
        }
    }

    //when level finishes
    public void onLevelLost()
    {
        if (!levelIsFinish) { 
            characterController.onIncorrectAnswer();
            onLevelFinish();
        }
    }

    //when level finishes
    public void onLevelFinish()
    {
        levelIsFinish = true;

        for (int i = 0; i < 6-numberOfCorrect; i++)
        {
            numberOfCorrect++;
            main.starsController.IncorrectAnswer();
        }

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
