using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignWordModalTimeBehaviour : MonoBehaviour
{
    public float maxTime;
    public float currentTime;
    public bool isStartTime;
    public Image timeIcon;
    private bool timeFlag;
    public SignModalController signModalController;
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
            signModalController.OnButtonPressed();
            timeFlag = false;
        }

        timeIcon.fillAmount = currentTime / maxTime;
    }
}
