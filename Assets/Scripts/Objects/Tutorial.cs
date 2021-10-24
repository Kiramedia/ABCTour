using System;
using UnityEngine;

/// <summary>
/// Tutorial object
/// </summary>
[Serializable]
public class Tutorial
{
    /// <summary>
    /// Define if the tutorial is for letter activity
    /// </summary>
    public bool isLetterTutorial;

    /// <summary>
    /// Path of the tutorial video
    /// </summary>
    public string videoPath;

    /// <summary>
    /// Sprite of the letter (only in case that isLetterTutorial is true)
    /// </summary>
    public Sprite letterSprite;

    /// <summary>
    /// Define the position of the camera in this tutorial
    /// </summary>
    public Vector3 camPosition;

    /// <summary>
    /// Define the zoom of the camera in this tutorial
    /// </summary>
    public float camProjection;

    /// <summary>
    /// Scene name to do the activity
    /// </summary>
    public string activityScene;

    /// <summary>
    /// Identification for the tutorial
    /// </summary>
    public int id;
}
