using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.Video; 

public class VideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer; 
    public GameObject videoGameObject;
    public GameObject videoButtons; 


    // Start is called before the first frame update
    void Start()
    {
        videoPlayer.loopPointReached += EndReached;
        videoButtons.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

     void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        videoGameObject.GetComponent<RawImage>().enabled = false;

        videoButtons.SetActive(true);
    }

    public void replay(){
        videoGameObject.GetComponent<RawImage>().enabled = true;

        videoPlayer.frame = 0; 
        videoPlayer.Play();
        
        videoButtons.SetActive(false);
    }
}
