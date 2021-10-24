using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class to define ball system for level 2
/// This serve for all elements that should be remove when user click activity item
/// </summary>
public class BallsSystem : MonoBehaviour
{

    /// <summary>
    /// List with balls gameobjects
    /// </summary>
    public List<GameObject> balls;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        //Random rotation for balls
        foreach (GameObject ball in balls)
        {
            ball.transform.eulerAngles = new Vector3(0, 0, Random.Range(0, 360));
        }
    }

    /// <summary>
    /// Method to disappear ball with the first position in the list
    /// When ball is removed, alse is change to inactive in the scene
    /// </summary>
    public void DisappearBall()
    {
        if (balls.Count > 0)
        {
            balls[0].SetActive(false);
            balls.RemoveAt(0);
        }
    }
}
