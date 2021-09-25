using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class to init level scenes
/// </summary>
public class StartLevel : MonoBehaviour
{
    public bool isTutorial = false;

    public SpriteRenderer[] imagePlayers;
    public SpriteRenderer[] iconImages;

    public Image Letter;
    public Image[] UIPlayers;
    public Image[] UIIcons;

    private Tutorial tutorialInfo;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        if(isTutorial){
            tutorialInfo = JsonUtility.FromJson<Tutorial>(PlayerPrefs.GetString("SelectedTutorial"));
        }
        InitPlayers();
    }

    void InitPlayers(){
        if(!isTutorial){
            if(imagePlayers[0] != null && iconImages[0] != null){
                Utils.SetPlayer("player1", imagePlayers[0], iconImages[0]);
            }

            if(imagePlayers[1] != null && iconImages[1] != null){
                Utils.SetPlayer("player2", imagePlayers[1], iconImages[1]);
            }
        }else{
            if(UIPlayers[0] != null && UIIcons[0] != null){
                Utils.SetPlayer("player1", UIPlayers[0], UIIcons[0]);
            }

            if(UIPlayers[1] != null && UIIcons[1] != null){
                Utils.SetPlayer("player2", UIPlayers[1], UIIcons[1]);
            }

            if(tutorialInfo != null){
                Letter.sprite = tutorialInfo.letterSprite;
                Camera.main.transform.localPosition = tutorialInfo.camPosition;
                Camera.main.orthographicSize = tutorialInfo.camProjection;
            }
        }
    }
}
