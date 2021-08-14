using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    /// <summary>
    /// Scene canvas
    /// </summary>
    Canvas myCanvas;

    /// <summary>
    /// Bool that indicates if scene start
    /// </summary>
    bool isStart;

    /// <summary>
    /// Cursor trail
    /// </summary>
    TrailRenderer trail;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        myCanvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>();
        Cursor.visible = false;
        trail = GetComponent<TrailRenderer>();
        isStart = false;
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(myCanvas.transform as RectTransform, Input.mousePosition, myCanvas.worldCamera, out pos);
        transform.position = myCanvas.transform.TransformPoint(pos);

        Animator loadingAnimator = GameObject.FindGameObjectWithTag("Loader").GetComponent<Animator>();

        if (loadingAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "LoaderFadeOut" && !isStart && loadingAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7 && !loadingAnimator.IsInTransition(0))
        {
            trail.enabled = true;
            isStart = true;
        }
        else if (trail.enabled && !isStart)
        {
            trail.enabled = false;
        }
    }

    /// <summary>
    /// Method to change cursor state
    /// </summary>
    /// <param name="state">cursor state</param>
    public void ChangeCursor(string state)
    {
        SpriteRenderer spRenderer = GetComponent<SpriteRenderer>();
        switch (state)
        {
            case "hover":
                spRenderer.color = new Color32(255, 159, 1, 255);
                break;
            case "default":
                spRenderer.color = new Color32(234, 214, 4, 255);
                break;
        }
    }
}
