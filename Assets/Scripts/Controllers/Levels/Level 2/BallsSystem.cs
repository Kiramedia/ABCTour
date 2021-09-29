using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsSystem : MonoBehaviour
{
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

    public void DisappearBall(){
        if(balls.Count > 0){
            balls[0].SetActive(false);
            balls.RemoveAt(0);
        }
    }
}
