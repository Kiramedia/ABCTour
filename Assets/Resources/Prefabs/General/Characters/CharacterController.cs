using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public CharacterEmotionController characterEmotionController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //when test answered correctly
    public void onCorrectAnswer()
    {
        characterEmotionController.onCorrectAnswer();
    }

    //when test answered incorrectly
    public void onIncorrectAnswer()
    {
        characterEmotionController.onIncorrectAnswer();
    }

    public void onBack(){
        characterEmotionController.onBack();
    }

    public void onNeutral(){
        characterEmotionController.onNeutral();
    }

    public void onHappy(){
        characterEmotionController.onHappy();
    }
}
