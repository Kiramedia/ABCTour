using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoTutorialController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public GameObject videoOptions;

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        videoOptions.SetActive(false);
        CheckVideoStatus();
    }

    void CheckVideoStatus(){
        if(videoPlayer.frame <= (long) videoPlayer.frameCount){
            videoOptions.SetActive(true);
        }
    }
}
