using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Update is called once per frame
    void Update()
    {

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
