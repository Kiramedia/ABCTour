
using UnityEngine;

public class FeedBackUI : MonoBehaviour
{
    public RectTransform fillBar;
    public float widthBar = 885;
    public int sections;
    private int currentSection;

    private float actPosition;
    public float duration = 1f;
    private bool isAnim = false;
    private float time = 0;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        currentSection = 0;
        actPosition = fillBar.sizeDelta.x;
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if(isAnim){
            fillBar.sizeDelta = new Vector2(Mathf.Lerp(actPosition, (widthBar/sections)*currentSection, time), fillBar.sizeDelta.y);
            time += Time.deltaTime/duration;

            if(time > 1f){
                time = 0;
                isAnim = false;
                fillBar.sizeDelta = new Vector2((widthBar/sections)*currentSection, fillBar.sizeDelta.y);
                actPosition = (widthBar/sections)*currentSection;
            }
        }
    }

    public void AddSection(){
        if(!isAnim && currentSection < sections){
            currentSection++;
            isAnim = true;
        }
    }

    public void SubstractSection(){
        if(!isAnim && currentSection > 0){
            currentSection--;
            isAnim = true;
        }
    }
}
