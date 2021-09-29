using UnityEngine;
using UnityEngine.UI;

public class StarsController : MonoBehaviour
{
    private RectMask2D mask2D;
    private float maxSize;
    public int numOfItems;
    public int possibleMisstakes;
    public int currentMisstakes;

    public int currentCorrect;
    public float duration = 1f;
    private float pointsToGive;

    private bool isAnim = false;
    private float time = 0;
    public float startPosition = 280;
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
        mask2D.padding = new Vector4(0, 0, startPosition, 0);
        pointsToGive = maxSize / numOfItems;
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if(isAnim && !main.isFinish){
            mask2D.padding = new Vector4(0, 0, Mathf.Lerp(startPosition, startPosition - pointsToGive, time), 0);
            time += Time.deltaTime/duration;

            if(time > 1f){
                time = 0;
                isAnim = false;
                mask2D.padding = new Vector4(0, 0, startPosition - pointsToGive, 0);
                startPosition = startPosition - pointsToGive;
            }
        }
    }
    
    public void CorrectAnswer(){
        if(!isAnim && !main.isFinish){
            currentCorrect++;
            if( currentMisstakes > possibleMisstakes ){
                float pointsInMisstake = maxSize / (numOfItems + (currentMisstakes - possibleMisstakes));
                float totalPoints = pointsInMisstake * currentCorrect;

                if(totalPoints > (maxSize - mask2D.padding.z)){
                    pointsToGive = totalPoints - (maxSize - mask2D.padding.z);
                }else{
                    pointsToGive = 0;
                }
            }

            startPosition = mask2D.padding.z;
            isAnim = true;
        }
    }

    public void IncorrectAnswer(){
        if(!main.isFinish){
            currentMisstakes++;
        }
    }
}