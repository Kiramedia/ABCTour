using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

/// <summary>
/// Configuration controller class
/// </summary>
public class ConfigController : MonoBehaviour
{
    /// <summary>
    /// Screen resolution dropdown
    /// </summary>
    [SerializeField]
    TMP_Dropdown screenResolution;

    /// <summary>
    /// Full screen checkbox
    /// </summary>
    [SerializeField]
    Toggle fullScreen;

    /// <summary>
    /// Haptic checkbox
    /// </summary>
    [SerializeField]
    Toggle haptic;

    /// <summary>
    /// Email text
    /// </summary>
    [SerializeField]
    TMP_Text email;

    /// <summary>
    /// Device text
    /// </summary>
    [SerializeField]
    TMP_Text device;

    /// <summary>
    /// Window resolutions for screen of the game
    /// </summary>
    Resolution[] resolutions;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        SetResolution();
        SetFullScreen();
        SetHaptic();
        SetEmail();
        SetDevice();
    }

    /// <summary>
    /// Set information in the resolution dropdown
    /// </summary>
    void SetResolution()
    {
        resolutions = NotRepeatResolutions();
        List<string> options = new List<string>();

        for (int i = 0; i < resolutions.Length; i++)
        {
            options.Add(ResToString(resolutions[i]));
        }
        screenResolution.ClearOptions();
        screenResolution.AddOptions(options);

        int screenSize = PlayerPrefs.GetInt("ScreenSize");
        if(screenSize >= 0){
            screenResolution.value = screenSize;
        }
    }

    /// <summary>
    /// Set status in the fullscreen toggle
    /// </summary>
    void SetFullScreen(){
        int fullScreenValue = PlayerPrefs.GetInt("FullScreen");
        fullScreen.isOn = fullScreenValue == -1 ? false : true;
    }

    /// <summary>
    /// Set status in the haptic toggle
    /// </summary>
    void SetHaptic(){
        int hapticValue = PlayerPrefs.GetInt("Haptic");
        haptic.isOn = hapticValue == -1 ? false : true;
    }

    /// <summary>
    /// Set email text to TMP_Text
    /// </summary>
    void SetEmail(){
        string emailValue = PlayerPrefs.GetString("Email").ToLower();
        if(emailValue != ""){
            string result = Utils.GetCensoredEmail(emailValue);
            email.text = result;
        }
    }

    /// <summary>
    /// Set device text to TMP_Text
    /// </summary>
    void SetDevice(){
        string actDevice = PlayerPrefs.GetString("Device");
        if(actDevice == ""){
            actDevice = Utils.CreateRandomTeamName();
            PlayerPrefs.SetString("Device", actDevice);
        }
        device.text = actDevice;
    }

    /// <summary>
    /// Method that create a resolutions array without repeat width and screen
    /// </summary>
    /// <returns>Array with available resolutions</returns>
    public static Resolution[] NotRepeatResolutions()
    {
        List<Resolution> resultResolutions = new List<Resolution>();
        List<Resolution> resolutionsTemp = new List<Resolution>(Screen.resolutions);
        resolutionsTemp.Reverse();
        foreach (Resolution item in resolutionsTemp)
        {
            if (item.refreshRate == 60)
            {
                resultResolutions.Add(item);
            }
        }
        return resultResolutions.ToArray();
    }

    /// <summary>
    /// Method executed when resolution change in dropdown
    /// </summary>
    public void ChangeResolution()
    {
        Screen.SetResolution(resolutions[screenResolution.value].width, resolutions[screenResolution.value].height, fullScreen.isOn);
        PlayerPrefs.SetInt("ScreenSize", screenResolution.value);
    }

    /// <summary>
    /// Method to get resolution with string format
    /// </summary>
    /// <param name="res">Resolution to convert</param>
    /// <returns>String with format (width x height)</returns>
    string ResToString(Resolution res)
    {
        return res.width + " x " + res.height;
    }

    /// <summary>
    /// Method executed when fullscreen checkbox change
    /// </summary>
    public void ChangeFullScreen(){
        Screen.fullScreen = fullScreen.isOn;
        PlayerPrefs.SetInt("FullScreen", fullScreen.isOn ? 1 : -1);
    }

    /// <summary>
    /// Method executed when haptic checkbox change
    /// </summary>
    public void ChangeHaptic(){
        PlayerPrefs.SetInt("Haptic", haptic.isOn ? 1 : -1);
    }

    /// <summary>
    /// Method to present alert in configurations scene
    /// </summary>
    /// <param name="alert">alert gameobject</param>
    public void PresentAlert(GameObject alert){
        alert.SetActive(true);
        AlertController alertController = alert.GetComponent<AlertController>();
        alertController.changeField.interactable = false;
        if(alertController.type == "Email"){
            alertController.changeField.text = Utils.GetCensoredEmail(PlayerPrefs.GetString("Email").ToLower());
        }else{
            alertController.changeField.text = PlayerPrefs.GetString(alertController.type);
        }
    }

    /// <summary>
    /// Method to close alert in configurations scene
    /// </summary>
    /// <param name="alert">alert gameobject</param>
    public void CloseAlert(GameObject alert){
        AlertController alertController = alert.GetComponent<AlertController>();
        alertController.Clear();
        alert.SetActive(false);
    }
}
