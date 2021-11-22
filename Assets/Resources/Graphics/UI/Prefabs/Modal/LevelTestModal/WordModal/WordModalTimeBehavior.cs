using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordModalTimeBehavior : MonoBehaviour
{
    public float maxTime;
    public float currentTime;
    public bool isStartTime;
    public Image timeIcon;
    private bool timeFlag;
    public int type = 0;
    public WordModalController wordModalController;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = maxTime;

        timeFlag = true;

        isStartTime = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isStartTime && currentTime > 0)
        {
            currentTime -= Time.deltaTime;
        }
        else if (timeFlag && currentTime <= 0)
        {
            if( type == 0 ){
                wordModalController.OnButtonPressed();
            } else {
                GameObject levelController = GameObject.FindGameObjectWithTag("LevelController");
                if(levelController != null){
                    WordSignWordLevelController wordSignWordLevelController = levelController.GetComponent<WordSignWordLevelController>();
                    wordSignWordLevelController.changeQuestion();
                }
            }
            
            timeFlag = false;
        }

        timeIcon.fillAmount = currentTime / maxTime;
    }
}
