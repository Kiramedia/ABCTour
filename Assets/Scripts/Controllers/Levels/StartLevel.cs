using UnityEngine;

/// <summary>
/// Class to init level scenes
/// </summary>
public class StartLevel : MonoBehaviour
{
    /// <summary>
    /// Test image player
    /// </summary>
    public SpriteRenderer imagePlayer1;
    /// <summary>
    /// Test image player
    /// </summary>
    public SpriteRenderer imagePlayer2;
    /// <summary>
    /// Test icon image
    /// </summary>
    public SpriteRenderer iconImage1;
    /// <summary>
    /// Test icon image
    /// </summary>
    public SpriteRenderer iconImage2;

    public Sprite boy;
    public Sprite girl;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        Player player1 = JsonUtility.FromJson<Player>(PlayerPrefs.GetString("player1"));
        imagePlayer1.material = player1.colorMaterial;
        iconImage1.sprite = player1.icon;
        if(player1.sex == "Boy"){
            imagePlayer1.sprite = boy;
        }else{
            imagePlayer1.sprite = girl;
        }

        if(imagePlayer2 != null){
            Player player2 = JsonUtility.FromJson<Player>(PlayerPrefs.GetString("player2"));
            imagePlayer2.material = player2.colorMaterial;
            iconImage2.sprite = player2.icon;
            if(player2.sex == "Boy"){
                imagePlayer2.sprite = boy;
            }else{
                imagePlayer2.sprite = girl;
            }
        }
    }
}
