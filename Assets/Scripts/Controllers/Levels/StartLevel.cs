using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

/// <summary>
/// Class to init level scenes
/// </summary>
public class StartLevel : MonoBehaviour
{
    /// <summary>
    /// Define if the scene is a tutorial for the level
    /// </summary>
    public bool isTutorial = false;

    /// <summary>
    /// Array with all sprite renderers for player 1
    /// </summary>
    public PlayerSpriteRenderer[] imagesPlayer1;

    /// <summary>
    /// Array with all sprite renderers for player 2 (if exist in the level)
    /// </summary>
    public PlayerSpriteRenderer[] imagesPlayer2;

    /// <summary>
    /// Array with all icon sprites renderers
    /// </summary>
    public SpriteRenderer[] iconImages;

    /// <summary>
    /// In case of tutorial scene, define the letter image
    /// </summary>
    public Image Letter;

    /// <summary>
    /// In case of tutorial scene, define the array of player images (normally have player 1 and player 2 images in this order)
    /// </summary>
    public Image[] UIPlayers;

    /// <summary>
    /// In case of tutorial scene, define the array of icon images
    /// </summary>
    public Image[] UIIcons;

    /// <summary>
    /// Gameobject that contains video player
    /// </summary>
    public GameObject videoObject;

    /// <summary>
    /// Object with tutorial information necessary to set the scene
    /// </summary>
    private Tutorial tutorialInfo;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        if (isTutorial)
        {
            tutorialInfo = JsonUtility.FromJson<Tutorial>(PlayerPrefs.GetString("SelectedTutorial"));
        }
        InitPlayers();
    }

    /// <summary>
    /// Method to init player customization for the scene
    /// </summary>
    void InitPlayers()
    {
        if (!isTutorial)
        {
            if (imagesPlayer1.Length > 0)
            {
                foreach (PlayerSpriteRenderer item in imagesPlayer1)
                {
                    Utils.SetPlayer("player1", item, null);
                }
            }

            if (imagesPlayer2.Length > 0)
            {
                foreach (PlayerSpriteRenderer item in imagesPlayer2)
                {
                    Utils.SetPlayer("player2", item, null);
                }
            }

            if (iconImages.Length > 0)
            {
                Utils.SetIcons("player1", iconImages);
            }
        }
        else
        {
            if (UIPlayers[0] != null && UIIcons[0] != null)
            {
                Utils.SetPlayer("player1", UIPlayers[0], UIIcons[0]);
            }

            if (UIPlayers[1] != null && UIIcons[1] != null)
            {
                Utils.SetPlayer("player2", UIPlayers[1], UIIcons[1]);
            }

            if (tutorialInfo != null)
            {
                Letter.sprite = tutorialInfo.letterSprite;
                Camera.main.transform.localPosition = tutorialInfo.camPosition;
                Camera.main.orthographicSize = tutorialInfo.camProjection;
                VideoPlayer videoPlayer = videoObject.GetComponentInChildren<VideoPlayer>();
                VideoClip videoClip = Resources.Load(tutorialInfo.videoPath, typeof(VideoClip)) as VideoClip;
                videoPlayer.clip = videoClip;
            }
        }
    }
}
