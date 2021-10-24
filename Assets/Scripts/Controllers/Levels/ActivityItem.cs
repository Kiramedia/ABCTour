using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class that represent activity item in the game
/// </summary>
public class ActivityItem : MonoBehaviour
{

    /// <summary>
    /// State that defines if this object is an answer or not
    /// </summary>
    public bool isAnswer;

    /// <summary>
    /// If this object is an answer, should exist the UI match parent to change its status
    /// </summary>
    public GameObject matchParent;

    /// <summary>
    /// State that defines if anim is present
    /// </summary>
    private bool isAnim = false;

    /// <summary>
    /// Current animation time (1 is the maximun)
    /// </summary>
    private float time = 0;

    /// <summary>
    /// Mask2D to animate the appearance of the UI object
    /// </summary>
    private RectMask2D mask2D;

    /// <summary>
    /// Have padding z RectMask2D last position
    /// </summary>
    private float startPosition;

    /// <summary>
    /// Animation duration
    /// </summary>
    public float duration = 0.5f;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        if (isAnswer)
        {
            mask2D = matchParent.transform.GetChild(3).GetComponent<RectMask2D>();
            startPosition = mask2D.padding.z;
        }
    }

    /// <summary>
    /// Method called when activity item is clicked, here change all necessary status depends of isAnswer variable
    /// </summary>
    public void SetAnswer()
    {
        MainLevelController main = GameObject.FindGameObjectWithTag("LevelController").GetComponent<MainLevelController>();
        SelectionActivity activity = GameObject.FindGameObjectWithTag("LevelController").GetComponent<SelectionActivity>();
        if (isAnswer)
        {
            isAnim = true;
            main.starsController.CorrectAnswer();
            matchParent.GetComponentInChildren<Animator>().SetBool("removeOverlay", true);
            activity.CheckIfFinish();
        }
        else
        {
            main.starsController.IncorrectAnswer();
            activity.ChangeTurn();
        }

        Animator animator = transform.GetChild(2).GetComponent<Animator>();
        animator.SetBool("isActive", true);
        ParticleSystem pSystem = transform.GetChild(3).GetComponent<ParticleSystem>();
        pSystem.Play(true);

        if (transform.GetChild(0).gameObject.activeSelf && transform.GetChild(1).gameObject.activeSelf)
        {
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

    /// <summary>
    /// Anim UIParent when this object is an answer
    /// </summary>
    void UpdateUIParent()
    {
        if (isAnim)
        {
            mask2D.padding = new Vector4(0, 0, Mathf.Lerp(startPosition, 0, time), 0);
            time += Time.deltaTime / duration;

            if (time > 1f)
            {
                time = 0;
                isAnim = false;
                mask2D.padding = new Vector4(0, 0, 0, 0);
            }
        }
    }

    /// <summary>
    /// Hide sprite activy item to not interfere with particles and answer icon animation
    /// </summary>
    /// <returns>Courutine</returns>
    IEnumerator HideItem()
    {
        yield return new WaitForSeconds(0.1f);
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(false);
    }
}
