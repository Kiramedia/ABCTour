
using UnityEngine;

public class ModalController : MonoBehaviour
{
    private Animator animator;
    private CanvasGroup canvasGroup;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        animator = GetComponent<Animator>();
        canvasGroup = GetComponent<CanvasGroup>();

        animator.SetBool("appear", false);
        canvasGroup.blocksRaycasts = false;
    }

    public void SetStatus(bool status){
        if(status){
            animator.SetBool("appear", true);
            canvasGroup.blocksRaycasts = true;
        } else{
            animator.SetBool("appear", false);
            canvasGroup.blocksRaycasts = false;
        }
    }
}
