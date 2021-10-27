using UnityEngine;
using UnityEngine.UI;

public class MemoryTimeBehaviour : MonoBehaviour
{
    public float maxTime;
    public float currentTime;
    public bool isStartTime;
    public Image timeIcon;
    public MemoryTestModalBehaviour memoryTestModalBehaviour;
    public MemoryLevelBehaviour memoryLevelBehaviour;

    private bool timeFlag;
    // Start is called before the first frame update
    void Start()
    {
        switch(memoryLevelBehaviour.level){
            case 1:
                maxTime = 300f;
                break;

            case 2:
                maxTime = 225f;
                break;

            case 3:
                maxTime = 150f;
                break;
            
            default:
                maxTime = 100f;
                break;
        }

        currentTime = maxTime;

        timeFlag = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (isStartTime && currentTime > 0) {
            currentTime -= Time.deltaTime;
        } else if (timeFlag && currentTime <= 0) {
            memoryTestModalBehaviour.onGameLost();
            timeFlag = false;
        }

        timeIcon.fillAmount = currentTime / maxTime;
    }
}
