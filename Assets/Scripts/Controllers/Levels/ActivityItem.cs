using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivityItem : MonoBehaviour
{
    public bool isAnswer;
    public GameObject matchParent;

    public void SetAnswer(){
        MainLevelController main = GameObject.FindGameObjectWithTag("LevelController").GetComponent<MainLevelController>();
        if(isAnswer){
            main.starsController.CorrectAnswer();
        }else{
            main.starsController.IncorrectAnswer();
        }
        gameObject.SetActive(false);
    }
}
