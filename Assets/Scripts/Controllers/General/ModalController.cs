
using UnityEngine;
using UnityEngine.Video;

/// <summary>
/// Class to control modals behavior, for example Backpack and Pause modal
/// </summary>
public class ModalController : MonoBehaviour
{
    /// <summary>
    /// Animator to set transition information, this allow smooth the appear
    /// </summary>
    private Animator animator;

    /// <summary>
    /// CanvasGroup that allows change opacity of all items
    /// </summary>
    private CanvasGroup canvasGroup;

    /// <summary>
    /// Cursor Trail that have problems with time.scale 0, for that it's necessary to change enable status in pause
    /// </summary>
    private TrailRenderer cursorTrail;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        animator = GetComponent<Animator>();
        canvasGroup = GetComponent<CanvasGroup>();
        GameObject cursor = GameObject.FindGameObjectWithTag("Cursor");
        if (cursor != null)
        {
            cursorTrail = cursor.GetComponent<TrailRenderer>();
        }

        animator.SetBool("appear", false);
        canvasGroup.blocksRaycasts = false;
    }

    /// <summary>
    /// Change active modal status, to appear or desappear object
    /// </summary>
    /// <param name="status">boolean with status information</param>
    public void SetStatus(bool status)
    {
        GameObject mainLevelController = GameObject.FindGameObjectWithTag("LevelController");

        if (status)
        {
            animator.SetBool("appear", true);
            canvasGroup.blocksRaycasts = true;
            PauseStatus(true);
            GameObject videoPlayerObject = GameObject.FindGameObjectWithTag("VideoPlayer");
            if (videoPlayerObject != null)
            {
                VideoPlayer videoPlayer = videoPlayerObject.GetComponentInChildren<VideoPlayer>();
                videoPlayer.Pause();
            }
            if (mainLevelController != null)
            {
                mainLevelController.GetComponent<MainLevelController>().inModal = true;
            }
        }
        else
        {
            animator.SetBool("appear", false);
            canvasGroup.blocksRaycasts = false;
            PauseStatus(false);
            GameObject videoPlayerObject = GameObject.FindGameObjectWithTag("VideoPlayer");
            if (videoPlayerObject != null)
            {
                VideoPlayer videoPlayer = videoPlayerObject.GetComponentInChildren<VideoPlayer>();
                videoPlayer.Play();
            }
            if (mainLevelController != null)
            {
                mainLevelController.GetComponent<MainLevelController>().inModal = false;
            }
        }
    }

    /// <summary>
    /// Method to change time scale to pause scene
    /// </summary>
    /// <param name="status">true to pause, false to run application</param>
    public void PauseStatus(bool status)
    {
        Time.timeScale = status ? 0 : 1;
        cursorTrail.enabled = !status;
    }
}
