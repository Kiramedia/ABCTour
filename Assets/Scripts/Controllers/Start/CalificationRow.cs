using UnityEngine;
using TMPro;

/// <summary>
/// This class represent a calification row in the view
/// </summary>
public class CalificationRow : MonoBehaviour
{
    /// <summary>
    /// Text level field - indicates level
    /// </summary>
    public TMP_Text level;

    /// <summary>
    /// Text teamName field - indicates the name of the device/student team
    /// </summary>
    public TMP_Text teamName;

    /// <summary>
    /// Text misstakes field - indicates the number of misstakes registered by the student(s)
    /// </summary>
    public TMP_Text misstakes;

    /// <summary>
    /// Text time field - indicates the time taken by the student(s) to reach the level
    /// </summary>
    public TMP_Text time;

    /// <summary>
    /// Text date field - indicates the date when the level was complete
    /// </summary>
    public TMP_Text date;

    /// <summary>
    /// Text hour field - indicates the hour when the level start
    /// </summary>
    public TMP_Text hour;

    /// <summary>
    /// Method for assign calification information in fields
    /// </summary>
    /// <param name="calification">Calification record</param>
    public void AssignInformation(Calification calification){
        level.text = calification.level.ToString();
        teamName.text = calification.teamName;
        misstakes.text = calification.misstakes.ToString();
        SetMisstakeColor(calification.misstakes);
        time.text = calification.time;
        date.text = calification.date;
        hour.text = calification.hour;
    }

    /// <summary>
    /// Method to change misstake color field according with the number of misstakes
    /// </summary>
    /// <param name="numMisstakes">number of misstakes by the student(s)</param>
    void SetMisstakeColor(int numMisstakes){
        if(numMisstakes == 0){
            misstakes.color = new Color32(88, 173, 14, 255);
        }else if(numMisstakes <=3){
            misstakes.color = new Color32(11, 112, 14, 255);
        }else if(numMisstakes <=6){
            misstakes.color = new Color32(229, 116, 14, 255);
        }else{
            misstakes.color = new Color32(211, 0, 0, 255);
        }
    }
}
