using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionActivity : MonoBehaviour
{
    public List<Vector2> possiblePositions;
    public List<Vector2> possibleUIPositions;
    public int numberOfItems;
    public List<ActivityItem> correctItems;
    public List<ActivityItem> incorrectItems;
    public List<RectTransform> UIItems;
    public int numOfCorrect = 0;
    public GameObject[] turns;
    public GameObject inGameObjects;
    public GameObject inGameUIObjects;
    public GameObject trophy;
    public Image whitePanel;
    public Tutorial tutorialInfo;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        InitObjectPositions();
        if(turns.Length == 2){
            turns[0].SetActive(true);
            turns[1].SetActive(false);
        }
        tutorialInfo = JsonUtility.FromJson<Tutorial>(PlayerPrefs.GetString("SelectedTutorial"));
    }

    void InitObjectPositions(){
        List<ActivityItem> correctTemporal = new List<ActivityItem>(correctItems);
        List<ActivityItem> incorrectTemporal =  new List<ActivityItem>(incorrectItems);

        List<Vector2> temporalPositions =  new List<Vector2>(possiblePositions);
        List<Vector2> temporalUIPositions =  new List<Vector2>(possibleUIPositions);
        

        for (int i = 0; i < numberOfItems; i++)
        {
            int indexPosition = Random.Range(0, temporalPositions.Count);
            if(correctTemporal.Count != 0){
                correctTemporal[0].gameObject.SetActive(true);
                correctTemporal[0].gameObject.transform.position = new Vector3(temporalPositions[indexPosition].x, temporalPositions[indexPosition].y, 0);
                correctTemporal.RemoveAt(0);
            }else if(incorrectTemporal.Count != 0){
                int indexIncorrect = Random.Range(0, incorrectTemporal.Count);
                incorrectTemporal[indexIncorrect].gameObject.SetActive(true);
                incorrectTemporal[indexIncorrect].gameObject.transform.position = new Vector3(temporalPositions[indexPosition].x, temporalPositions[indexPosition].y, 0);
                incorrectTemporal.RemoveAt(indexIncorrect);
            }else{
                break;
            }

            temporalPositions.RemoveAt(indexPosition);
        }

        foreach (RectTransform UIItem in UIItems)
        {
            int indexPosition = Random.Range(0, temporalUIPositions.Count);
            UIItem.anchoredPosition = temporalUIPositions[indexPosition];
            temporalUIPositions.RemoveAt(indexPosition);
        }
    }

    public void CheckIfFinish(){
        numOfCorrect++;
        if(numOfCorrect >= correctItems.Count){
            if(turns.Length == 2){
                turns[0].SetActive(false);
                turns[1].SetActive(false);
            }
            
            MainLevelController main = GameObject.FindGameObjectWithTag("LevelController").GetComponent<MainLevelController>();
            Tutorial tutorialInfo = JsonUtility.FromJson<Tutorial>(PlayerPrefs.GetString("SelectedTutorial"));
            
            if(!main.levelData.currentTrophys.Contains(tutorialInfo.id)){
                main.levelData.currentTrophys.Add(tutorialInfo.id);
            }

            main.progressBar.AddSection(true);

            StartCoroutine(ChangeToPrincipal(main));
        }else{
            ChangeTurn();
        }
    }

    public void ChangeTurn(){
        if(turns.Length == 2 && turns[0].activeSelf){
            turns[0].SetActive(false);
            turns[1].SetActive(true);
        }else if(turns.Length == 2){
            turns[0].SetActive(true);
            turns[1].SetActive(false);
        }
    }

    IEnumerator ChangeToPrincipal(MainLevelController main){
        yield return new WaitForSeconds(1f);

        inGameObjects.SetActive(false);
        inGameUIObjects.SetActive(false);
        whitePanel.color = new Color32(255, 255, 255, 0);
        trophy.SetActive(true);

        yield return new WaitForSeconds(5f);
        SceneController sceneController = GameObject.FindGameObjectWithTag("Loader").GetComponent<SceneController>();
        main.SaveLevelData();
        sceneController.LoadScene("Level " + main.levelData.level.numberLevel);
    }
}
