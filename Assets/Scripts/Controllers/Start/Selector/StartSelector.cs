using UnityEngine;

public class StartSelector : MonoBehaviour
{
    public GameObject toPlayer1;
    public GameObject toPlayer2;
    public ParentSelectorController actualParent;
    private Level selectedLevel;
    private int numOfPlayers;

    void Start()
    {
        SetNumberOfPlayers();
    }

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

    public void ChangeHoverButton(){
        actualParent.ChangeButtonHover();
    }

    public void ContinueToLevel(){
        actualParent.ContinueToLevel(selectedLevel);
    }
}
