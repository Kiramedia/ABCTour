using UnityEngine;

/// <summary>
/// Class to control animators states and functions
/// </summary>
[RequireComponent(typeof(Animator))]
public class AnimatorController : MonoBehaviour
{
    /// <summary>
    /// Animator necessary to control states
    /// </summary>
    Animator animator;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    /// <summary>
    /// Method to controll boolean parameters in animator
    /// </summary>
    /// <param name="anim">Boolean parameter of animator</param>
    public void SetBoolAnim(string anim)
    {
        bool state = animator.GetBool(anim);
        animator.SetBool(anim, !state);

        CursorController cursor = GameObject.FindGameObjectWithTag("Cursor").GetComponent<CursorController>();
        if (state && cursor.isActiveAndEnabled)
        {
            cursor.ChangeCursor("default");
        }
        else
        {
            cursor.ChangeCursor("hover");
        }
    }
}
