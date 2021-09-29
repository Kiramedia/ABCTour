using UnityEngine;

/// <summary>
/// 
/// </summary>
public class BusAppear : MonoBehaviour
{
    /// <summary>
    /// In principal scene of the level, have a busObject that appears when all trophies are won
    /// </summary>
    public GameObject busObject;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        GameObject mainLevelController = GameObject.FindGameObjectWithTag("LevelController");
        if (mainLevelController != null)
        {
            if (mainLevelController.GetComponent<MainLevelController>().isFinish)
            {
                busObject.SetActive(true);
            }
            else
            {
                busObject.SetActive(false);
            }
        }
    }
}
