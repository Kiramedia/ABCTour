using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class VideoTutorialController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public GameObject videoOptions;
    public RawImage renderTexture;

    private Tutorial tutorialInfo;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        tutorialInfo = JsonUtility.FromJson<Tutorial>(PlayerPrefs.GetString("SelectedTutorial"));
    }

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        videoOptions.SetActive(false);
        videoPlayer.loopPointReached += CheckOver;
    }

    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        renderTexture.enabled = false;
        videoOptions.SetActive(true);
    }

    public void RepeatVideo(){
        videoPlayer.Play();
        videoOptions.SetActive(false);
        StartCoroutine(EnableTexture());
    }

    IEnumerator EnableTexture(){
        yield return new WaitForSeconds(0.1f);
        renderTexture.enabled = true;
    }

    public void StartActivity(){
        MainLevelController levelController = GameObject.FindGameObjectWithTag("LevelController").GetComponent<MainLevelController>();
        levelController.progressBar.AddSection(false);
        levelController.SaveLevelData();
        GameObject.FindGameObjectWithTag("Loader").GetComponent<SceneController>().LoadScene(tutorialInfo.activityScene);
    }
}
