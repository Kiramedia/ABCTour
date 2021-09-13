using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class to control player selector, this confirm if level is for two or one player(s)
/// </summary>
public class ParentSelectorController : MonoBehaviour
{
    /// <summary>
    /// Gameobject for first player (left modal)
    /// </summary>
    public GameObject player1;

    /// <summary>
    /// Gameobject for second player (right modal)
    /// </summary>
    public GameObject player2;

    /// <summary>
    /// Selector controller for first player (left modal)
    /// </summary>
    private SelectorController conPlayer1;

    /// <summary>
    /// Selector controller for second player (right modal)
    /// </summary>
    private SelectorController conPlayer2;

    /// <summary>
    /// Gameobject with icons to pick for the player
    /// </summary>
    public GameObject iconPicker;

    /// <summary>
    /// Gameobject of the continue button for avalaible porpouses
    /// </summary>
    public GameObject continueButton;

    /// <summary>
    /// Array of image to change enable/disable color for continue button
    /// </summary>
    public Image[] continueButtonImages;

    /// <summary>
    /// Material for disabled porpouses
    /// </summary>
    public Material grayMaterial;

    /// <summary>
    /// List of images to change for icon selected (normally in player shirt)
    /// </summary>
    public Image[] iconImages;

    /// <summary>
    /// List of icon sprites (white sprites)
    /// </summary>
    public Sprite[] icons;

    /// <summary>
    /// Number to define icon selected (0..iconImage.Length)
    /// </summary>
    public int iconSelected;

    /// <summary>
    /// State that defines if sex of player 1 is selected
    /// </summary>
    private bool isPlayer1Selected;

    /// <summary>
    /// State that defines if sex of player 2 is selected
    /// </summary>
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

    /// <summary>
    /// Method to set color for player 1 modal
    /// </summary>
    /// <param name="color">Index of the color</param>
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

    /// <summary>
    /// Method to set color for player 2 modal
    /// </summary>
    /// <param name="color">Index of the color</param>
    public void SetPlayer2Color(int color){
        if(conPlayer1.selectedColor != color){
            conPlayer2.SetColor(color);
            conPlayer1.DisableColor(color);
        }
    }

    /// <summary>
    /// Method to set icon in icon images array
    /// </summary>
    /// <param name="icon">Index of the icon</param>
    public void SetIcon(int icon){
        foreach (Image image in iconImages)
        {
            image.sprite = icons[icon];
        }
        iconPicker.transform.GetChild(iconSelected).GetComponent<Image>().color = new Color32(255, 187, 193, 255);
        iconPicker.transform.GetChild(icon).GetComponent<Image>().color = new Color32(255, 174, 1, 255);
        iconSelected = icon;
    }

    /// <summary>
    /// Method to change continue button state
    /// </summary>
    /// <param name="state">Indicates if is disable or enable</param>
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

    /// <summary>
    /// Method to verify and set if the continue button can be in hover
    /// </summary>
    public void ChangeButtonHover(){
        if(isPlayer1Selected && (isPlayer2Selected || player2 == null)){
            continueButton.GetComponent<AnimatorController>().SetBoolAnim("inHover");
        }
    }
    
    /// <summary>
    /// Method to set selected players state
    /// </summary>
    /// <param name="player">Num of the player (1 for the left, 2 for the right modal)</param>
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

    /// <summary>
    /// Method to change level when continue button is enable
    /// Create and set player(s) information in player prefs
    /// </summary>
    /// <param name="selectedLevel">Indicate the level selected in level scene</param>
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

    /// <summary>
    /// Method that set selector information in player object
    /// </summary>
    /// <param name="selector">controller of player to create</param>
    /// <returns>Player record with the selected information</returns>
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
