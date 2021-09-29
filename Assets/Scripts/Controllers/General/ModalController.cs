
using UnityEngine;
using UnityEngine.Video;

public class ModalController : MonoBehaviour
{
    private Animator animator;
    private CanvasGroup canvasGroup;
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
        if(cursor != null){
            cursorTrail = cursor.GetComponent<TrailRenderer>();
        }

        animator.SetBool("appear", false);
        canvasGroup.blocksRaycasts = false;
    }

    public void SetStatus(bool status){
        GameObject mainLevelController = GameObject.FindGameObjectWithTag("LevelController");

        if(status){
            animator.SetBool("appear", true);
            canvasGroup.blocksRaycasts = true;
            PauseStatus(true);
            GameObject videoPlayerObject = GameObject.FindGameObjectWithTag("VideoPlayer");
            if(videoPlayerObject != null){
                VideoPlayer videoPlayer = videoPlayerObject.GetComponentInChildren<VideoPlayer>();
                videoPlayer.Pause();
            }
            if(mainLevelController != null){
                mainLevelController.GetComponent<MainLevelController>().inModal = true;
            }
        } else{
            animator.SetBool("appear", false);
            canvasGroup.blocksRaycasts = false;
            PauseStatus(false);
            GameObject videoPlayerObject = GameObject.FindGameObjectWithTag("VideoPlayer");
            if(videoPlayerObject != null){
                VideoPlayer videoPlayer = videoPlayerObject.GetComponentInChildren<VideoPlayer>();
                videoPlayer.Play();
            }
            if(mainLevelController != null){
                mainLevelController.GetComponent<MainLevelController>().inModal = false;
            }
        }
    }

    public void PauseStatus(bool status){
        Time.timeScale = status ? 0: 1;
        cursorTrail.enabled = !status;
    }
}
