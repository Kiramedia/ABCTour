using UnityEngine;
using TMPro;
using UnityEngine.UI;

/// <summary>
/// Alert class to display modals with password information
/// </summary>
public class AlertController : MonoBehaviour
{
    /// <summary>
    /// Password input field link
    /// </summary>
    public TMP_InputField passwordField;
    /// <summary>
    /// Parameter that the usar wants to change input field link
    /// </summary>
    public TMP_InputField changeField;
    /// <summary>
    /// Parameter that the usar wants to change image link
    /// </summary>
    public Image changeImage;
    /// <summary>
    /// Parameter that the usar wants to change text link
    /// </summary>
    public TMP_Text changeText;
    /// <summary>
    /// Parameter that the usar wants to change label link
    /// </summary>
    public TMP_Text changeLabel;
    /// <summary>
    /// Confirm/save button text link
    /// </summary>
    public TMP_Text buttonText;
    /// <summary>
    /// Error text link
    /// </summary>
    public TMP_Text error;
    /// <summary>
    /// Optional text link to update with playerpref information
    /// </summary>
    public TMP_Text updatedText;
    /// <summary>
    /// Alert type that indicates the different functionalities 
    /// </summary>
    public string type;

    /// <summary>
    /// Confirm method to change alert status
    /// </summary>
    public void Confirm()
    {
        if (buttonText.text == "Confirmar")
        {
            if ("TestPassword" == passwordField.text)
            {
                changeImage.color = new Color32(255, 67, 90, 255);
                changeLabel.color = new Color32(0, 0, 0, 255);
                changeText.color = new Color32(0, 0, 0, 255);
                changeField.interactable = true;
                changeField.text = PlayerPrefs.GetString(type);
                buttonText.text = "Guardar";
                error.text = "";
            }
            else
            {
                error.text = "Contraseña incorrecta, intente de nuevo";
            }
        }
        else if (buttonText.text == "Guardar")
        {
            PlayerPrefs.SetString(type, changeField.text);
            if(updatedText != null){
                if(type == "Email"){
                    updatedText.text = Utils.GetCensoredEmail(PlayerPrefs.GetString("Email").ToLower());
                }else{
                    updatedText.text = PlayerPrefs.GetString(type);
                }
            }
            Clear();
            gameObject.SetActive(false);
        }
        else
        {
            //In development errors
            Clear();
        }
    }

    /// <summary>
    /// Method to set default values in the objects
    /// </summary>
    public void Clear()
    {
        passwordField.text = "";
        changeImage.color = new Color32(153, 153, 153, 255);
        changeLabel.color = new Color32(153, 153, 153, 255);
        changeText.color = new Color32(153, 153, 153, 255);
        changeField.interactable = false;
        buttonText.text = "Confirmar";
        error.text = "";
    }
}
