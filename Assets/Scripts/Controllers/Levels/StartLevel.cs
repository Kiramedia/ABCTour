using UnityEngine;

public class StartLevel : MonoBehaviour
{
    public SpriteRenderer imagePlayer;
    public SpriteRenderer iconImage;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        Player player1 = JsonUtility.FromJson<Player>(PlayerPrefs.GetString("player1"));
        imagePlayer.material = player1.colorMaterial;
        iconImage.sprite = player1.icon;
    }
}
