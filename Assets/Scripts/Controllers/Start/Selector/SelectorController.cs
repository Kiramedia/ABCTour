using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class to controll selector modal
/// Here you can set sex, color and icon of the player
/// </summary>
public class SelectorController : MonoBehaviour
{
    /// <summary>
    /// Define what player is, first or second
    /// </summary>
    public int numberPlayer;
    
    /// <summary>
    /// Image of the boy in the modal
    /// </summary>
    public Image boyObject;

    /// <summary>
    /// Boy black overlay
    /// </summary>
    public GameObject boyOverlay;

    /// <summary>
    /// Image of the girl in the modal
    /// </summary>
    public Image girlObject;

    /// <summary>
    /// Girl black overlay
    /// </summary>
    public GameObject girlOverlay;

    /// <summary>
    /// Array of boy color materials
    /// </summary>
    public Material[] boyMaterials;

    /// <summary>
    /// Array of girl color materials
    /// </summary>
    public Material[] girlMaterials;

    /// <summary>
    /// Gameobject with colors to pick for the player
    /// </summary>
    public GameObject colorPicker;

    /// <summary>
    /// Back gameobject to change color pickers state
    /// </summary>
    public GameObject colorPickerBack;

    /// <summary>
    /// Array with colors
    /// Have all color pickers values
    /// </summary>
    public Color[] colors;

    /// <summary>
    /// State information of the player sex
    /// </summary>
    public string selectedSex;

    /// <summary>
    /// State information of the player color
    /// </summary>
    public int selectedColor;

    /// <summary>
    /// Boolean that define if color picker have disabled color
    /// </summary>
    public bool isDisabledColor;

    /// <summary>
    /// Index of the disabled color when isDisbleColor is true
    /// </summary>
    public int disabledColor;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        selectedSex = "";
        colorPickerBack.transform.GetChild(selectedColor).GetComponent<Image>().enabled = true;
        boyObject.material = boyMaterials[selectedColor];
        girlObject.material = girlMaterials[selectedColor];
        if(isDisabledColor){
            DisableColor(disabledColor);
        }
    }

    /// <summary>
    /// Method to change sex state
    /// </summary>
    /// <param name="sex">text with sex information ("Boy" and "Girl")</param>
    public void SelectSex(string sex){
        if(sex == "Boy"){
            boyOverlay.SetActive(false);
            girlOverlay.SetActive(true);
            selectedSex = "Boy";
        }else{
            boyOverlay.SetActive(true);
            girlOverlay.SetActive(false);
            selectedSex = "Girl";
        }
    }

    /// <summary>
    /// Method to change color state
    /// </summary>
    /// <param name="index">Index of the color selected</param>
    public void SetColor(int index){
        boyObject.material = boyMaterials[index];
        girlObject.material = girlMaterials[index];
        colorPickerBack.transform.GetChild(selectedColor).GetComponent<Image>().enabled = false;
        colorPickerBack.transform.GetChild(index).GetComponent<Image>().enabled = true;
        selectedColor = index;
    }

    /// <summary>
    /// Method to change the disable color in the color picker
    /// </summary>
    /// <param name="index">Index of the disable color</param>
    public void DisableColor(int index){
        colorPicker.transform.GetChild(disabledColor).GetComponent<Image>().color = colors[disabledColor];
        colorPicker.transform.GetChild(disabledColor).GetChild(0).GetComponent<Image>().enabled = false;
        colorPicker.transform.GetChild(index).GetComponent<Image>().color = Color.gray;
        colorPicker.transform.GetChild(index).GetChild(0).GetComponent<Image>().enabled = true;
        disabledColor = index;
    }
}
