
using UnityEngine;

/// <summary>
/// Class to controll progress bar feedback
/// </summary>
public class FeedBackUI : MonoBehaviour
{
    /// <summary>
    /// RectTransform that contains bar
    /// The idea is change width to create fill effect
    /// </summary>
    public RectTransform fillBar;

    /// <summary>
    /// Width of the bar, to know activities positions
    /// </summary>
    public float widthBar = 885;

    /// <summary>
    /// Number of sections that have the progress bar
    /// </summary>
    public int sections;

    /// <summary>
    /// Define the current section of the bar
    /// </summary>
    public int currentSection;

    /// <summary>
    /// Define the current position (width)
    /// </summary>
    private float actPosition;

    /// <summary>
    /// Animation duration
    /// </summary>
    public float duration = 1f;

    /// <summary>
    /// Animator state
    /// </summary>
    private bool isAnim = false;

    /// <summary>
    /// Current animation time (1 is the maximun)
    /// </summary>
    private float time = 0;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        fillBar.sizeDelta = new Vector2((widthBar / sections) * currentSection, fillBar.sizeDelta.y);
        actPosition = fillBar.sizeDelta.x;
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if (isAnim)
        {
            fillBar.sizeDelta = new Vector2(Mathf.Lerp(actPosition, (widthBar / sections) * currentSection, time), fillBar.sizeDelta.y);
            time += Time.deltaTime / duration;

            if (time > 1f)
            {
                time = 0;
                isAnim = false;
                fillBar.sizeDelta = new Vector2((widthBar / sections) * currentSection, fillBar.sizeDelta.y);
                actPosition = (widthBar / sections) * currentSection;
            }
        }
    }

    /// <summary>
    /// Change to the next section (with animation)
    /// </summary>
    /// <param name="anim">define if should animated or not</param>
    public void AddSection(bool anim)
    {
        if (!isAnim && currentSection < sections)
        {
            currentSection++;
            isAnim = anim;
        }
    }

    /// <summary>
    /// Change to the before section (with animation)
    /// Method in necessary case
    /// </summary>
    public void SubstractSection()
    {
        if (!isAnim && currentSection > 0)
        {
            currentSection--;
            isAnim = true;
        }
    }
}
