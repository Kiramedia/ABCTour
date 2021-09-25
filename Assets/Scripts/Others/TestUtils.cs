using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class for util methods
/// </summary>
public class TestUtils : MonoBehaviour
{ 
    /// <summary>
    /// Created with test purposes
    /// Create calification test data
    /// </summary>
    public static void CalificationTestData(){
        
        List<Calification> califications = new List<Calification>();
        
        Calification cal1 = new Calification();
        cal1.level = 1;
        cal1.teamName = "Kela Team";
        cal1.misstakes = 0;
        cal1.time = "0h 37m 0s";
        cal1.date = "30/08/2021";
        cal1.hour = "09:51";

        Calification cal2 = new Calification();
        cal2.level = 2;
        cal2.teamName = "Kira Team";
        cal2.misstakes = 3;
        cal2.time = "0h 07m 03s";
        cal2.date = "30/08/2021";
        cal2.hour = "10:09";

        Calification cal3 = new Calification();
        cal3.level = 3;
        cal3.teamName = "KiraxKela Team";
        cal3.misstakes = 5;
        cal3.time = "0h 07m 03s";
        cal3.date = "30/08/2021";
        cal3.hour = "10:09";

        Calification cal4 = new Calification();
        cal4.level = 4;
        cal4.teamName = "Let's get married with me baby";
        cal4.misstakes = 7;
        cal4.time = "0h 07m 03s";
        cal4.date = "30/08/2021";
        cal4.hour = "10:09";

        califications.Add(cal1);
        califications.Add(cal2);
        califications.Add(cal3);
        califications.Add(cal4);

        CalificationCollection collection = new CalificationCollection();
        collection.califications = califications.ToArray();

        string json = JsonUtility.ToJson(collection);
        PlayerPrefs.SetString("Calification", json);
    }

    /// <summary>
    /// Created with test purposes
    /// Create level test data
    /// </summary>
    public static void LevelTestData() { 
        List<Level> levels = new List<Level>();
        
        Level level1 = new Level();
        level1.numberLevel = 1;
        level1.isDifficultyVariant = false;
        level1.numberOfPlayers = 2;

        Level level2 = new Level();
        level2.numberLevel = 2;
        level2.isDifficultyVariant = false;
        level2.numberOfPlayers = 2;

        Level level3 = new Level();
        level3.numberLevel = 3;
        level3.isDifficultyVariant = true;
        level3.actualDifficult = 0;
        level3.numberOfPlayers = 1;

        Level level4 = new Level();
        level4.numberLevel = 4;
        level4.isDifficultyVariant = true;
        level4.actualDifficult = 0;
        level4.numberOfPlayers = 2;

        levels.Add(level1);
        levels.Add(level2);
        levels.Add(level3);
        levels.Add(level4);

        LevelCollection collection = new LevelCollection();
        collection.levels = levels.ToArray();

        string json = JsonUtility.ToJson(collection);
        PlayerPrefs.SetString("Levels", json);
    }

    public static Sprite LoadSprite(){
        return Resources.Load("Graphics/Backgrounds/Level 1/Letters/a", typeof(Sprite)) as Sprite;
    }
}