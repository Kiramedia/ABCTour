using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivityTrigger : MonoBehaviour
{
    public int trophyIndex;
    public SpriteRenderer icon;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        MainLevelController main = GameObject.FindGameObjectWithTag("LevelController").GetComponent<MainLevelController>();
        BoxCollider2D collider2D = transform.GetComponent<BoxCollider2D>();
        if(main.levelData.currentTrophys.Contains(trophyIndex) && !main.isFinish){
            icon.enabled = false;
            collider2D.enabled = false;
        }else if(main.isFinish){
            icon.enabled = true;
            collider2D.enabled = true;
            icon.sprite = Resources.Load("Graphics/Levels/Repeat", typeof(Sprite)) as Sprite;
        }
    }
}
