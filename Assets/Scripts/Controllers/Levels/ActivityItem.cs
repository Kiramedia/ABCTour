using System.Collections;
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
        
        Animator animator = transform.GetChild(2).GetComponent<Animator>();
        animator.SetBool("isActive", true);
        ParticleSystem pSystem = transform.GetChild(3).GetComponent<ParticleSystem>();
        pSystem.Play(true);

        if(transform.GetChild(0).gameObject.activeSelf && transform.GetChild(1).gameObject.activeSelf){
            StartCoroutine(HideItem());
        }
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

    IEnumerator HideItem(){
        yield return new WaitForSeconds(0.1f);
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(false);
    }
}
