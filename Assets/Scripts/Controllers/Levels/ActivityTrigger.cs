using UnityEngine;

/// <summary>
/// Class to change Letter icon status (mision or repeat)
/// </summary>
public class ActivityTrigger : MonoBehaviour
{
    /// <summary>
    /// Trophy index associated to the letter
    /// </summary>
    public int trophyIndex;

    /// <summary>
    /// Icon renderer to change the sprite with the status
    /// </summary>
    public SpriteRenderer icon;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        MainLevelController main = GameObject.FindGameObjectWithTag("LevelController").GetComponent<MainLevelController>();
        BoxCollider2D collider2D = transform.GetComponent<BoxCollider2D>();
        if (main.levelData.currentTrophies.Contains(trophyIndex) && !main.isFinish)
        {
            icon.enabled = false;
            collider2D.enabled = false;
        }
        else if (main.isFinish)
        {
            icon.enabled = true;
            collider2D.enabled = true;
            icon.sprite = Resources.Load("Graphics/Levels/Repeat", typeof(Sprite)) as Sprite;
        }
    }
}
