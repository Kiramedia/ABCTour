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

        Utils.InitLevelsData();
        Utils.CalificationData();
    }

    
}
