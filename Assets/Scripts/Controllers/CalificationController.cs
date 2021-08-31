using UnityEngine;
using System.Collections.Generic;
using System;

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
        //createTestData(); //Only for test purposes
        SetCalifications();
    }

    /// <summary>
    /// Method that initialize califications in row fields
    /// </summary>
    void SetCalifications(){
        CalificationCollection collection = JsonUtility.FromJson<CalificationCollection>(PlayerPrefs.GetString("Calification"));
        for (int i = 0; i < collection.califications.Length; i++)
        {
            rows[i].AssignInformation(collection.califications[i]);
        }
    }

    /// <summary>
    /// Created with test purposes.
    /// </summary>
    void createTestData(){
        List<Calification> califications = new List<Calification>();
        
        Calification level1 = new Calification();
        level1.level = 1;
        level1.teamName = "Kela Team";
        level1.misstakes = 0;
        level1.time = "0h 37m 0s";
        level1.date = "30/08/2021";
        level1.hour = "09:51";

        Calification level2 = new Calification();
        level2.level = 2;
        level2.teamName = "Kira Team";
        level2.misstakes = 3;
        level2.time = "0h 07m 03s";
        level2.date = "30/08/2021";
        level2.hour = "10:09";

        Calification level3 = new Calification();
        level3.level = 3;
        level3.teamName = "KiraxKela Team";
        level3.misstakes = 5;
        level3.time = "0h 07m 03s";
        level3.date = "30/08/2021";
        level3.hour = "10:09";

        Calification level4 = new Calification();
        level4.level = 4;
        level4.teamName = "Let's get married with me baby";
        level4.misstakes = 7;
        level4.time = "0h 07m 03s";
        level4.date = "30/08/2021";
        level4.hour = "10:09";

        califications.Add(level1);
        califications.Add(level2);
        califications.Add(level3);
        califications.Add(level4);

        CalificationCollection collection = new CalificationCollection();
        collection.califications = califications.ToArray();

        string json = JsonUtility.ToJson(collection);
        PlayerPrefs.SetString("Calification", json);
    }
}
