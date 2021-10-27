using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Controller to select the difficult when level have these
/// </summary>
public class DifficultController : MonoBehaviour
{
    /// <summary>
    /// Baby image for easy difficult
    /// </summary>
    public Image baby;

    /// <summary>
    /// Child image for intermediate difficult
    /// </summary>
    public Image child;

    /// <summary>
    /// Teen image for hard difficult
    /// </summary>
    public Image teen;

    /// <summary>
    /// Bar object to give feedback of difficult selected
    /// </summary>
    public RectTransform bar;

    /// <summary>
    /// Arrow object to give feedback of difficult selected
    /// </summary>
    public RectTransform arrow;

    /// <summary>
    /// Material for disabled porpouses
    /// </summary>
    public Material grayMaterial;

    /// <summary>
    /// Difficults avalaible (0 for easy, 1 for easy and intermediate, 2 for all)
    /// </summary>
    private int actAvalaibleDifficult;

    /// <summary>
    /// State that defines the current selected difficult
    /// </summary>
    private int currentDifficult;

    // Bar parameters

    /// <summary>
    /// Duration of the bar animation
    /// </summary>
    public float animDuration = 1f;

    /// <summary>
    /// Current time of the bar animation
    /// </summary>
    float time = 0;

    /// <summary>
    /// State that defines if bar is updating (for animation porpouses)
    /// </summary>
    bool barUpdating = false;

    /// <summary>
    /// State that defines if the difficult modal is enable or disabled
    /// </summary>
    bool isActive = true;
    Level selectedLevel;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        selectedLevel = JsonUtility.FromJson<Level>(PlayerPrefs.GetString("selectedLevel"));
        actAvalaibleDifficult = selectedLevel.actualDifficult;
        currentDifficult = actAvalaibleDifficult;
        PlayerPrefs.SetInt("selectedDifficult", actAvalaibleDifficult);
    }



    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        UpdateUIInformation();
        if(selectedLevel.numberLevel != JsonUtility.FromJson<Level>(PlayerPrefs.GetString("selectedLevel")).numberLevel){
            selectedLevel = JsonUtility.FromJson<Level>(PlayerPrefs.GetString("selectedLevel"));
            actAvalaibleDifficult = selectedLevel.actualDifficult;
            currentDifficult = actAvalaibleDifficult;
            PlayerPrefs.SetInt("selectedDifficult", actAvalaibleDifficult);
            SetDifficultState(true);
        }
    }

    /// <summary>
    /// Method to set difficult state, change the current difficult if is possible
    /// </summary>
    /// <param name="state">Define if is enable or disable</param>
    public void SetDifficultState(bool state)
    {
        isActive = state;
        if (state)
        {
            barUpdating = true;
            currentDifficult = PlayerPrefs.GetInt("selectedDifficult");
            arrow.gameObject.SetActive(true);
            bar.gameObject.SetActive(true);
            switch (actAvalaibleDifficult)
            {
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
        }
        else
        {
            arrow.gameObject.SetActive(false);
            bar.gameObject.SetActive(false);
            baby.material = grayMaterial;
            child.material = grayMaterial;
            teen.material = grayMaterial;
        }
    }

    /// <summary>
    /// Method to update bar animation
    /// </summary>
    void UpdateUIInformation()
    {
        if (barUpdating && time <= animDuration)
        {
            time += Time.fixedDeltaTime;
            bar.sizeDelta = new Vector2(Mathf.Lerp(bar.sizeDelta.x, (currentDifficult + 1) * 100, 0.1f), bar.sizeDelta.y);
            arrow.anchoredPosition = new Vector2(Mathf.Lerp(arrow.anchoredPosition.x, ((currentDifficult * 100) + 63), 0.1f), arrow.anchoredPosition.y);
        }
        else
        {
            time = 0;
            barUpdating = false;
        }
    }

    /// <summary>
    /// Method called when button with difficult is pressed
    /// Verify if the difficult is avalabile and if the modal is active
    /// </summary>
    /// <param name="difficult">Selected difficult index</param>
    public void ClickDifficult(int difficult)
    {
        if (difficult <= actAvalaibleDifficult && isActive)
        {
            barUpdating = true;
            currentDifficult = difficult;
            PlayerPrefs.SetInt("selectedDifficult", difficult);
        }
    }
}
