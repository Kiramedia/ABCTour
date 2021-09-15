using UnityEngine;

public class Loading : MonoBehaviour
{
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        string sceneName = PlayerPrefs.GetString("loadingToScene");
        GameObject.FindGameObjectWithTag("Loader").GetComponent<SceneController>().LoadAsycScene(sceneName);
    }
}
