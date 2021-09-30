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
    public List<Sign> usedSigns;
    private GameObject currentTestModal;
    // Start is called before the first frame update
    void Start()
    {
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
        numberOfQuestionsAnswered++;

        instantiateTestModal();
    }

    //when test answered incorrectly
    public void onIncorrectAnswer()
    {
        numberOfMistakes++;
        numberOfQuestionsAnswered++;

        if (numberOfQuestionsAnswered >= numberOfQuestions)
            onLevelFinish();
        else instantiateTestModal();
    }

    //when level finishes
    public void onLevelFinish()
    {

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
}
