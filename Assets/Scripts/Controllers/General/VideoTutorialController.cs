using System.Collections;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

/// <summary>
/// Class to control videoplayer behaviour
/// </summary>
public class VideoTutorialController : MonoBehaviour
{
    /// <summary>
    /// VideoPlayer component
    /// </summary>
    public VideoPlayer videoPlayer;

    /// <summary>
    /// Gameobject that contains videoplayer options to display these when clip finish
    /// </summary>
    public GameObject videoOptions;

    /// <summary>
    /// Image that contains RenderTexture to display video
    /// </summary>
    public RawImage renderTexture;

    /// <summary>
    /// Tutorial record that have the information that should be display
    /// </summary>
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

    /// <summary>
    /// Method called when clip is finished
    /// </summary>
    /// <param name="vp">Videoplayer to check clip information</param>
    void CheckOver(VideoPlayer vp)
    {
        renderTexture.enabled = false;
        videoOptions.SetActive(true);
    }

    /// <summary>
    /// Method to repeat video when repeat option is clicked
    /// </summary>
    public void RepeatVideo()
    {
        videoPlayer.Play();
        videoOptions.SetActive(false);
        StartCoroutine(EnableTexture());
    }

    /// <summary>
    /// IEnumerator method to wait 0.1f before to display texture (this is for visual bug)
    /// </summary>
    /// <returns>Courutine</returns>
    IEnumerator EnableTexture()
    {
        yield return new WaitForSeconds(0.1f);
        renderTexture.enabled = true;
    }

    /// <summary>
    /// Method to continue with the activity when continuos option is clicked
    /// </summary>
    public void StartActivity()
    {
        MainLevelController levelController = GameObject.FindGameObjectWithTag("LevelController").GetComponent<MainLevelController>();
        levelController.progressBar.AddSection(false);
        levelController.SaveLevelData();
        GameObject.FindGameObjectWithTag("Loader").GetComponent<SceneController>().LoadScene(tutorialInfo.activityScene);
    }
}
