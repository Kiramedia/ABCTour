using UnityEngine;
using UnityEngine.UI;

public class DifficultController : MonoBehaviour
{
    public Image baby;
    public Image child;
    public Image teen;
    public RectTransform bar;
    public RectTransform arrow;
    public Material grayMaterial;
    private int actAvalaibleDifficult;
    private int currentDifficult;

    // Bar parameters
    public float animDuration = 1f;
    float time = 0;
    bool barUpdating = false;
    bool isActive = true;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        actAvalaibleDifficult = PlayerPrefs.GetInt("actDifficultAvalaible");
        currentDifficult = actAvalaibleDifficult;
        PlayerPrefs.SetInt("selectedDifficult", actAvalaibleDifficult);
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        UpdateUIInformation();
    }

    public void SetDifficultState(bool state){
        isActive = state;
        if(state){
            barUpdating = true;
            currentDifficult = PlayerPrefs.GetInt("selectedDifficult");
            arrow.gameObject.SetActive(true);
            bar.gameObject.SetActive(true);
            switch(actAvalaibleDifficult){
                case 0:
                    baby.material = null;
                    child.material = grayMaterial;
                    teen.material = grayMaterial;
                    break;
                case 1:
                    baby.material = null;
                    child.material = null;
                    teen.material = grayMaterial;
                    break;
                case 2:
                    baby.material = null;
                    child.material = null;
                    teen.material = null;
                    break;
                default:
                    child.material = grayMaterial;
                    teen.material = grayMaterial;
                    break;
            }
        }else{
            arrow.gameObject.SetActive(false);
            bar.gameObject.SetActive(false);
            baby.material = grayMaterial;
            child.material = grayMaterial;
            teen.material = grayMaterial;
        }
    }

    void UpdateUIInformation(){
        if(barUpdating && time <= animDuration){
            time += Time.fixedDeltaTime;
            bar.sizeDelta = new Vector2(Mathf.Lerp(bar.sizeDelta.x, (currentDifficult+1)*100, 0.1f), bar.sizeDelta.y);
            arrow.anchoredPosition = new Vector2(Mathf.Lerp(arrow.anchoredPosition.x, ((currentDifficult*100) + 63), 0.1f), arrow.anchoredPosition.y);
        }else {
            time = 0;
            barUpdating = false;
        }
    }

    public void ClickDifficult(int difficult){
        if(difficult <= actAvalaibleDifficult && isActive){
            barUpdating = true;
            currentDifficult = difficult;
            PlayerPrefs.SetInt("selectedDifficult", difficult);
        }
    }
}
