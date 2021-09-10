using UnityEngine;
using UnityEngine.UI;

public class ParentSelectorController : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;

    private SelectorController conPlayer1;
    private SelectorController conPlayer2;

    public GameObject iconPicker;

    public Image[] iconImages;
    public Sprite[] icons;
    public int iconSelected;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        conPlayer1 = player1.GetComponent<SelectorController>();
        if(player2 != null){
            conPlayer2 = player2.GetComponent<SelectorController>();
        }
        SetIcon(iconSelected);
    }

    public void SetPlayer1Color(int color){
        if(player2 != null){
            if(conPlayer2.selectedColor != color){
                conPlayer1.SetColor(color);
                conPlayer2.DisableColor(color);
            }
        }else{
            conPlayer1.SetColor(color);
        }
    }

    public void SetPlayer2Color(int color){
        if(conPlayer1.selectedColor != color){
            conPlayer2.SetColor(color);
            conPlayer1.DisableColor(color);
        }
    }

    public void SetIcon(int icon){
        foreach (Image image in iconImages)
        {
            image.sprite = icons[icon];
            
        }
        iconPicker.transform.GetChild(iconSelected).GetComponent<Image>().color = new Color32(255, 187, 193, 255);
        iconPicker.transform.GetChild(icon).GetComponent<Image>().color = new Color32(255, 174, 1, 255);
        iconSelected = icon;
    }
}
