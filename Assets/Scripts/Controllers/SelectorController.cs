using UnityEngine;
using UnityEngine.UI;

public class SelectorController : MonoBehaviour
{
    public int numberPlayer;
    public Image boyObject;
    public GameObject boyOverlay;
    public Image girlObject;
    public GameObject girlOverlay;
    public Material[] boyMaterials;
    public Material[] girlMaterials;

    public GameObject colorPickerBack;

    private string selectedSex;
    public int selectedColor;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        selectedSex = "";
        colorPickerBack.transform.GetChild(selectedColor).GetComponent<Image>().enabled = true;
    }

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

    public void SetColor(int index){
        boyObject.material = boyMaterials[index];
        girlObject.material = girlMaterials[index];
        colorPickerBack.transform.GetChild(selectedColor).GetComponent<Image>().enabled = false;
        colorPickerBack.transform.GetChild(index).GetComponent<Image>().enabled = true;
        selectedColor = index;
    }
}
