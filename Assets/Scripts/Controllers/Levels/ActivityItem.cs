using UnityEngine;
using UnityEngine.UI;

public class ActivityItem : MonoBehaviour
{
    public bool isAnswer;

    public GameObject matchParent;

    private bool isAnim = false;
    private float time = 0;
    private RectMask2D mask2D;
    private float startPosition;
    public float duration = 1f;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        if(isAnswer){
            mask2D = matchParent.transform.GetChild(3).GetComponent<RectMask2D>();
            startPosition = mask2D.padding.z;
        }
    }

    public void SetAnswer(){
        MainLevelController main = GameObject.FindGameObjectWithTag("LevelController").GetComponent<MainLevelController>();
        SelectionActivity activity = GameObject.FindGameObjectWithTag("LevelController").GetComponent<SelectionActivity>();
        if(isAnswer){
            isAnim = true;
            main.starsController.CorrectAnswer();
            matchParent.GetComponentInChildren<Animator>().SetBool("removeOverlay", true);
            activity.CheckIfFinish();
        }else{
            main.starsController.IncorrectAnswer();
            activity.ChangeTurn();
        }
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(false);
        
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        UpdateUIParent();
    }

    void UpdateUIParent(){
        if(isAnim){
            mask2D.padding = new Vector4(0, 0, Mathf.Lerp(startPosition, 0, time), 0);
            time += Time.deltaTime/duration;

            if(time > 1f){
                time = 0;
                isAnim = false;
                mask2D.padding = new Vector4(0, 0, 0, 0);
            }
        }
    }
}
