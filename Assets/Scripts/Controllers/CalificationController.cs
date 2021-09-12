using UnityEngine;

/// <summary>
/// Calification controller class for seting information in calification teacher view
/// </summary>
public class CalificationController : MonoBehaviour
{
    /// <summary>
    /// List of rows with calification fields
    /// </summary>
    [SerializeField]
    CalificationRow[] rows;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        //TestUtils.CalificationTestData(); //Only for test purposes
        SetCalifications();
    }

    /// <summary>
    /// Method that initialize califications in row fields
    /// </summary>
    void SetCalifications(){
        CalificationCollection collection = JsonUtility.FromJson<CalificationCollection>(PlayerPrefs.GetString("Calification"));
        if(collection != null){
            for (int i = 0; i < collection.califications.Length; i++)
            {
                rows[i].AssignInformation(collection.califications[i]);
            }
        }
    }
}
