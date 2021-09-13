using UnityEngine;

/// <summary>
/// Class to start the selector scene
/// </summary>
public class StartSelector : MonoBehaviour
{
    /// <summary>
    /// Gameobject for 1 player selector
    /// </summary>
    public GameObject toPlayer1;

    /// <summary>
    /// Gameobject for 2 player selector
    /// </summary>
    public GameObject toPlayer2;

    /// <summary>
    /// Defines the current parent selector active
    /// Depends of number of players in the selected level
    /// </summary>
    public ParentSelectorController actualParent;

    /// <summary>
    /// Record that defines the level selected in level scene
    /// </summary>
    private Level selectedLevel;

    
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        SetNumberOfPlayers();
    }

    /// <summary>
    /// Define what modal is going to display in the selector scene
    /// Depends of number of players in the selected level
    /// </summary>
    void SetNumberOfPlayers(){
        selectedLevel = JsonUtility.FromJson<Level>(PlayerPrefs.GetString("selectedLevel"));

        if(selectedLevel.numberOfPlayers == 1){
            toPlayer1.SetActive(true);
            toPlayer2.SetActive(false);
            actualParent = toPlayer1.gameObject.GetComponent<ParentSelectorController>();
        }else{
            toPlayer1.SetActive(false);
            toPlayer2.SetActive(true);
            actualParent = toPlayer2.gameObject.GetComponent<ParentSelectorController>();
        }
    }

    /// <summary>
    /// Method to call parent button hover method from button trigger event
    /// </summary>
    public void ChangeHoverButton(){
        actualParent.ChangeButtonHover();
    }

    /// <summary>
    /// Method to call parent button continue to level method from button trigger event
    /// </summary>
    public void ContinueToLevel(){
        actualParent.ContinueToLevel(selectedLevel);
    }
}
