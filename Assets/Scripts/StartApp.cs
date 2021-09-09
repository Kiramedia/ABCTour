using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Class to init all start configurations
/// </summary>
public class StartApp : MonoBehaviour
{
    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        initApp();
    }

    /// <summary>
    /// Method executed when aplication is started.
    /// Set all save configurations.
    /// </summary>
    void initApp(){
        int screenSize = PlayerPrefs.GetInt("ScreenSize");
        if(screenSize >= 0){
            Resolution[] resolutions = ConfigController.NotRepeatResolutions();
            Screen.SetResolution(resolutions[screenSize].width, resolutions[screenSize].height, true);
        }
        
        int fullScreen = PlayerPrefs.GetInt("FullScreen");
        Screen.fullScreen = fullScreen == -1 ? false : true;

        if(PlayerPrefs.GetString("Levels") == null || PlayerPrefs.GetString("Levels") == ""){
            InitLevelsData();
        }
    }

    /// <summary>
    /// Create level data to start application first time
    /// </summary>
    void InitLevelsData(){
        List<Level> levels = new List<Level>();
        
        Level level1 = new Level();
        level1.numberLevel = 1;
        level1.isDifficultyVariant = false;

        Level level2 = new Level();
        level2.numberLevel = 2;
        level2.isDifficultyVariant = false;

        Level level3 = new Level();
        level3.numberLevel = 3;
        level3.isDifficultyVariant = true;
        level3.actualDifficult = 0;

        Level level4 = new Level();
        level4.numberLevel = 4;
        level4.isDifficultyVariant = true;
        level4.actualDifficult = 0;

        levels.Add(level1);
        levels.Add(level2);
        levels.Add(level3);
        levels.Add(level4);

        LevelCollection collection = new LevelCollection();
        collection.levels = levels.ToArray();

        string json = JsonUtility.ToJson(collection);
        PlayerPrefs.SetString("Levels", json);
        PlayerPrefs.SetInt("actLevelAvalaible", 1);
    }
}
