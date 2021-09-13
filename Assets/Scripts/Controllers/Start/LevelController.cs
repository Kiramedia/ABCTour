using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class to swipe level information created by Todo sobre Unity3d
/// Channel link https://www.youtube.com/channel/UCeXba0QM17gpmzaiV71w1AQ
/// Modify by ABCTour team
/// </summary>
public class LevelController : MonoBehaviour
{
    /// <summary>
    /// Array with state color for the bottom buttons
    /// </summary>
    public Color[] colors;

    /// <summary>
    /// Scrollbar information
    /// </summary>
    public GameObject scrollbar, imageContent;

    /// <summary>
    /// Scroll position
    /// </summary>
    private float scroll_pos = 0;

    /// <summary>
    /// Array with scroll positions for the level containers
    /// </summary>
    float[] pos;

    /// <summary>
    /// State for scroll animations
    /// </summary>
    private bool runIt = false;

    /// <summary>
    /// Current time for scroll animation
    /// </summary>
    private float time;

    /// <summary>
    /// Current focus button
    /// </summary>
    private Button takeTheBtn;

    /// <summary>
    /// Index of the focus button
    /// </summary>
    int btnNumber;

    /// <summary>
    /// Index of the current selected level
    /// </summary>
    int currentSelectedLevel;

    /// <summary>
    /// Indicate the level last level avalaible, > 0 [1..]
    /// </summary>
    int actLevel;

    /// <summary>
    /// Material for disabled porpouses
    /// </summary>
    public Material grayScaleMaterial;

    /// <summary>
    /// Distance between level containers
    /// </summary>
    private float distance;

    /// <summary>
    /// Gameobjects array with boy and girl modal, [0] for difficult gameobject, [1] for boy, [2] for girl
    /// </summary>
    public GameObject[] difficulties;

    /// <summary>
    /// Levels array with all levels information
    /// </summary>
    private Level[] levels;

    /// <summary>
    /// Selected random difficulty modal, boy or girl in 50% of changes
    /// </summary>
    private GameObject selectedDifficultStyle;

    /// <summary>
    /// Defines what is the last difficult level selected
    /// </summary>
    private int difficultLevel;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        SetLevelData();
        GetPositions();
        GetLevelsInformation();
        SetDificulty();
    }

    /// <summary>
    /// Method to get and set current and actual level
    /// </summary>
    void SetLevelData(){
        actLevel = PlayerPrefs.GetInt("actLevelAvalaible");
        actLevel = actLevel == 0 ? 1 : actLevel;
        currentSelectedLevel = actLevel - 1;
    }

    /// <summary>
    /// Obtain the levels information to know what difficult information displays or not
    /// </summary>
    void GetLevelsInformation(){
        levels = JsonUtility.FromJson<LevelCollection>(PlayerPrefs.GetString("Levels")).levels;
    }

    /// <summary>
    /// Get position for the scrollbar
    /// </summary>
    void GetPositions(){
        pos = new float[transform.childCount];
        distance = 1f / (pos.Length-0.8f);

        for (int i = 0; i < pos.Length; i++)
        {
            pos[i] = distance * i;
        }

        btnNumber = actLevel-1;
        time = 0;
        scroll_pos = (pos[btnNumber]);
        runIt = true;
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        MoveScrollbar();
        CheckDragScrollbar();
        UpdateUIAndStates();
    }

    /// <summary>
    /// Update scrollbar and UI Information
    /// </summary>
    private void UpdateUIAndStates(){
        for (int i = 0; i < pos.Length; i++)
        {
            if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
            {
                currentSelectedLevel = i;
                SetDificulty();

                transform.GetChild(i).localScale = Vector2.Lerp(transform.GetChild(i).localScale, new Vector2(1f, 1f), 0.1f);
                imageContent.transform.GetChild(i).localScale = Vector2.Lerp(imageContent.transform.GetChild(i).localScale, new Vector2(1.0f, 1.0f), 0.1f);
                SetColor(imageContent.transform.GetChild(i).GetComponent<Image>(), 
                    imageContent.transform.GetChild(i).GetChild(0).GetComponent<Text>(), 
                    colors[1], colors[0], i);
                SetMaterial(transform.GetChild(i).GetComponent<Image>(), i);
                transform.GetChild(i).GetChild(0).GetComponent<Image>().enabled = false;

                SetNotSelectedValues();
            }
        }
    }

    /// <summary>
    /// Method for set difficult information and UI
    /// </summary>
    private void SetDificulty(){
        if(levels[currentSelectedLevel].isDifficultyVariant && (!difficulties[0].activeSelf || difficultLevel != currentSelectedLevel)){
            difficulties[0].SetActive(true);
            
            if(selectedDifficultStyle == null || difficultLevel != currentSelectedLevel){
                if(Random.value > 0.5f){
                    selectedDifficultStyle = difficulties[1];
                    difficulties[1].SetActive(true);
                    difficulties[2].SetActive(false);
                    if(currentSelectedLevel < actLevel){
                        difficulties[1].GetComponent<DifficultController>().SetDifficultState(true);
                    }else{
                        difficulties[1].GetComponent<DifficultController>().SetDifficultState(false);
                    }
                }else{
                    selectedDifficultStyle = difficulties[2];
                    difficulties[1].SetActive(false);
                    difficulties[2].SetActive(true);
                    if(currentSelectedLevel < actLevel){
                        difficulties[2].GetComponent<DifficultController>().SetDifficultState(true);
                    }else{
                        difficulties[2].GetComponent<DifficultController>().SetDifficultState(false);
                    }
                }
            }

            difficultLevel = currentSelectedLevel;
        }else if(!levels[currentSelectedLevel].isDifficultyVariant){
            selectedDifficultStyle = null;
            difficulties[0].SetActive(false);
        }
    }

    /// <summary>
    /// Method to move the Scrollbar to button position
    /// </summary>
    private void MoveScrollbar(){
        if (runIt)
        {
            GecisiDuzenle(distance, pos, takeTheBtn);
            time += Time.deltaTime;

            if (time > 1f)
            {
                time = 0;
                runIt = false;
            }
        }
    }

    /// <summary>
    /// Method to check scrollbar drag and set the value to button position
    /// </summary>
    private void CheckDragScrollbar(){
        if (Input.GetMouseButton(0))
        {
            scroll_pos = scrollbar.GetComponent<Scrollbar>().value;
        }
        else
        {
            for (int i = 0; i < pos.Length; i++)
            {
                if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
                {
                    scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollbar.GetComponent<Scrollbar>().value, pos[i], 0.1f);
                }
            }
        }
    }

    /// <summary>
    /// Method for move scrollbar to button
    /// </summary>
    /// <param name="distance">Is the distance between the buttons</param>
    /// <param name="pos">Array with center button positions</param>
    /// <param name="btn">Button to move scrollbar</param>
    private void GecisiDuzenle(float distance, float[] pos, Button btn)
    {
        // btnSayi = System.Int32.Parse(btn.transform.name);

        for (int i = 0; i < pos.Length; i++)
        {
            if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
            {
                scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollbar.GetComponent<Scrollbar>().value, pos[btnNumber], 1f * Time.deltaTime);

            }
        }

        if(btn != null){
            for (int i = 0; i < btn.transform.parent.transform.childCount; i++)
            {
                btn.transform.name = ".";
            }
        }
    }

    /// <summary>
    /// Method to update not selected buttons styles, information and UI
    /// </summary>
    private void SetNotSelectedValues(){
        for (int j = 0; j < pos.Length; j++)
        {
            if (j != currentSelectedLevel)
            {
                SetColor(imageContent.transform.GetChild(j).GetComponent<Image>(), 
                    imageContent.transform.GetChild(j).GetChild(0).GetComponent<Text>(), 
                    colors[0], colors[1], j);
                SetMaterial(transform.GetChild(j).GetComponent<Image>(), j);

                imageContent.transform.GetChild(j).localScale = Vector2.Lerp(imageContent.transform.GetChild(j).localScale, new Vector2(0.8f, 0.8f), 0.1f);
                transform.GetChild(j).localScale = Vector2.Lerp(transform.GetChild(j).localScale, new Vector2(0.8f, 0.8f), 0.1f);
                transform.GetChild(j).GetChild(0).GetComponent<Image>().enabled = true;
            }
        }
    }

    /// <summary>
    /// Method to set the material to the sprite, if the level isn't available displays in grayScale
    /// </summary>
    /// <param name="sprite">Image to check what material set</param>
    /// <param name="index">Index to check with actual level</param>
    private void SetMaterial(Image sprite, int index){
        if(index < actLevel){
            sprite.material = null;
        }else{
            sprite.material = grayScaleMaterial;
        }
    }

    /// <summary>
    /// Method to set the colors in the objects and update UI
    /// </summary>
    /// <param name="sprite">Image to change color</param>
    /// <param name="text">Text to change color</param>
    /// <param name="color">Color image</param>
    /// <param name="textColor">Text color</param>
    /// <param name="index">Index to check with actual level</param>
    private void SetColor(Image sprite, Text text, Color32 color, Color32 textColor, int index){
        if(index < actLevel){
            sprite.color = color;
            text.color = textColor;
        }else{
            sprite.color = new Color32(158, 158, 158, 255);
            text.color = colors[0];
        }
    }

    /// <summary>
    /// Method executed when button it's clicked
    /// </summary>
    /// <param name="btn">button clicked</param>
    public void WhichBtnClicked(Button btn)
    {
        btn.transform.name = "clicked";
        for (int i = 0; i < btn.transform.parent.transform.childCount; i++)
        {
            if (btn.transform.parent.transform.GetChild(i).transform.name == "clicked")
            {
                btnNumber = i;
                takeTheBtn = btn;
                time = 0;
                scroll_pos = (pos[btnNumber]);
                runIt = true;
            }
        }
    }

    /// <summary>
    /// Method for EventTrigger navigator buttons, call the button functions and if is necessary move the scrollbar
    /// </summary>
    /// <param name="i">Index of the level clicked</param>
    public void LevelBtnClicked(int i)
    {
        if(currentSelectedLevel != i){
            btnNumber = i;
            time = 0;
            scroll_pos = (pos[btnNumber]);
            runIt = true;
        }else if(i < actLevel){
            PlayerPrefs.SetString("selectedLevel", JsonUtility.ToJson(levels[i]));
            GameObject.FindGameObjectWithTag("Loader").GetComponent<SceneController>().LoadScene("Start - Selector");
        }
    }
}