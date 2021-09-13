using UnityEngine;
using UnityEngine.UI;

public class ParentSelectorController : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;

    private SelectorController conPlayer1;
    private SelectorController conPlayer2;

    public GameObject iconPicker;

    public GameObject continueButton;
    public Image[] continueButtonImages;
    public Material grayMaterial;

    public Image[] iconImages;
    public Sprite[] icons;
    public int iconSelected;

    private bool isPlayer1Selected;
    private bool isPlayer2Selected;

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
        ChangeButtonEnable(false);

        isPlayer1Selected = false;
        isPlayer2Selected = false;
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

    public void ChangeButtonEnable(bool state){
        foreach (Image image in continueButtonImages)
        {
            if(state){
                image.material = null;
            }else{
                image.material = grayMaterial;
            }
            
        }
    }

    public void ChangeButtonHover(){
        if(isPlayer1Selected && (isPlayer2Selected || player2 == null)){
            continueButton.GetComponent<AnimatorController>().SetBoolAnim("inHover");
        }
    }

    public void SelectPlayer(int player){
        if(player == 1){
            isPlayer1Selected = true;
        }else{
            isPlayer2Selected = true;
        }

        if(isPlayer1Selected && (isPlayer2Selected || player2 == null)){
            ChangeButtonEnable(true);
        }
    }

    public void ContinueToLevel(Level selectedLevel){
        if(isPlayer1Selected && (isPlayer2Selected || player2 == null)){
            Player playerInfo1 = CreatePlayerInformation(conPlayer1);
            PlayerPrefs.SetString("player1", JsonUtility.ToJson(playerInfo1));
            if(player2 != null){
                Player playerInfo2 = CreatePlayerInformation(conPlayer2);
                PlayerPrefs.SetString("player2", JsonUtility.ToJson(playerInfo2));
            }

            GameObject.FindGameObjectWithTag("Loader").GetComponent<SceneController>().LoadScene("Level " + selectedLevel.numberLevel);
        }
    }

    Player CreatePlayerInformation(SelectorController selector){
        Player player = new Player();
        player.sex = selector.selectedSex;
        if(player.sex == "Boy"){
            player.colorMaterial = selector.boyMaterials[selector.selectedColor];
        }else{
            player.colorMaterial = selector.girlMaterials[selector.selectedColor];
        }
        
        player.icon = icons[iconSelected];

        return player;
    }
}
