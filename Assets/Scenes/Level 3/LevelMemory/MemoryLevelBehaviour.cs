using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryLevelBehaviour : MonoBehaviour
{
    // [NonSerialized]
    public int numberOfMistakes;
    // [NonSerialized]
    public int level;
    public float waitTime;
    public CharacterController characterController;

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
        characterController.onCorrectAnswer();
    }

    //when test answered incorrectly
    public void onIncorrectAnswer()
    {
        numberOfMistakes++;

        characterController.onIncorrectAnswer();
    }

    //when level finishes
    public void onLevelWon()
    {
        characterController.onCorrectAnswer();
        onLevelFinish();
    }

    //when level finishes
    public void onLevelLost()
    {
        characterController.onIncorrectAnswer();
        onLevelFinish();
    }

    //when level finishes
    public void onLevelFinish()
    {
        Debug.Log("Aquí Kevin hace el final del nivel");
    }
}
