using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeBehaviour : MonoBehaviour
{
    public float maxTime;
    public float currentTime;
    public bool isStartTime;
    public Image timeIcon;
    public TestModalController testModalController;
    private bool timeFlag;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = maxTime;

        timeFlag = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isStartTime && currentTime > 0) {
            currentTime -= Time.deltaTime;
        } else if (timeFlag && currentTime <= 0) {
            testModalController.onIncorrectAnswer();
            timeFlag = false;
        }

        timeIcon.fillAmount = currentTime / maxTime;
    }
}
