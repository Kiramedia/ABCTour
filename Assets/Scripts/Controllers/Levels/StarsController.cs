using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class to controll all starts system
/// This allow to create anim effects and give feedback to the user
/// </summary>
public class StarsController : MonoBehaviour
{
    /// <summary>
    /// RectMask2D that have padding information to create start anim effect
    /// </summary>
    private RectMask2D mask2D;

    /// <summary>
    /// MaxSize of the mask2D
    /// </summary>
    private float maxSize;

    /// <summary>
    /// Number of items in all the level
    /// </summary>
    public int numOfItems;

    /// <summary>
    /// Define the possible misstakes that have the user
    /// If the user overpass this, it can't obtain 5 starts
    /// </summary>
    public int possibleMisstakes;

    /// <summary>
    /// Define the count of misstakes of the user in the experience
    /// </summary>
    public int currentMisstakes;

    /// <summary>
    /// Define the count of correct selected items of the user
    /// </summary>
    public int currentCorrect;

    /// <summary>
    /// Animation duration
    /// </summary>
    public float duration = 1f;

    /// <summary>
    /// This is the most important variable, have the points to set in the star system when user click a correct item
    /// </summary>
    private float pointsToGive;

    /// <summary>
    /// Animation state
    /// </summary>
    private bool isAnim = false;

    /// <summary>
    /// Current animation time (1 is the maximun)
    /// </summary>
    private float time = 0;

    /// <summary>
    /// Have the last position of mask2D
    /// Is called "Start" because define the position to start the animation
    /// </summary>
    public float startPosition = 280;

    /// <summary>
    /// Object with main level controller information
    /// </summary>
    private MainLevelController main;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        main = GameObject.FindGameObjectWithTag("LevelController").GetComponent<MainLevelController>();
        mask2D = GetComponent<RectMask2D>();
        maxSize = mask2D.padding.z;
        GetStartPosition();
        mask2D.padding = new Vector4(0, 0, startPosition, 0);
        pointsToGive = maxSize / numOfItems;
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if (isAnim && !main.isFinish)
        {
            mask2D.padding = new Vector4(0, 0, Mathf.Lerp(startPosition, startPosition - pointsToGive, time), 0);
            time += Time.deltaTime / duration;

            if (time > 1f)
            {
                time = 0;
                isAnim = false;
                mask2D.padding = new Vector4(0, 0, startPosition - pointsToGive, 0);
                startPosition = startPosition - pointsToGive;
            }
        }
    }

    /// <summary>
    /// Get Start position for the starts system (this fix some visual bugs)
    /// </summary>
    void GetStartPosition()
    {
        float totalPoints = startPosition;

        if (currentMisstakes > possibleMisstakes)
        {
            float pointsInMisstake = maxSize / (numOfItems + (currentMisstakes - possibleMisstakes));
            totalPoints = maxSize - (pointsInMisstake * currentCorrect);

            if (totalPoints > startPosition)
            {
                totalPoints = startPosition;
            }
        }
        else
        {
            float pointsNormally = maxSize / numOfItems;
            totalPoints = maxSize - (pointsNormally * currentCorrect);
        }

        startPosition = totalPoints;
    }

    /// <summary>
    /// Method called when user clicked a correct answer
    /// </summary>
    public void CorrectAnswer()
    {
        if (!main.isFinish)
        {
            currentCorrect++;
            if (currentMisstakes > possibleMisstakes)
            {
                float pointsInMisstake = maxSize / (numOfItems + (currentMisstakes - possibleMisstakes));
                float totalPoints = pointsInMisstake * currentCorrect;

                if (totalPoints > (maxSize - mask2D.padding.z))
                {
                    pointsToGive = totalPoints - (maxSize - mask2D.padding.z);
                }
                else
                {
                    pointsToGive = 0;
                }
            }

            startPosition = mask2D.padding.z;
            if (!isAnim)
            {
                isAnim = true;
            }
            else
            {
                time = 0;
            }

        }
    }

    /// <summary>
    /// Method called when user clicked a incorrect answer
    /// </summary>
    public void IncorrectAnswer()
    {
        if (!main.isFinish)
        {
            currentMisstakes++;
        }
    }
}
