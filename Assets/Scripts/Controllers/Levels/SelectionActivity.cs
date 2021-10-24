using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class to control all selection level activity
/// </summary>
public class SelectionActivity : MonoBehaviour
{
    /// <summary>
    /// List with possible positions for the activityItems
    /// </summary>
    public List<Vector2> possiblePositions;

    /// <summary>
    /// List with possible position for the MathParent of the activityItems
    /// </summary>
    public List<Vector2> possibleUIPositions;

    /// <summary>
    /// Define the number of objects of the activity
    /// </summary>
    public int numberOfItems;

    /// <summary>
    /// List with the correct activity items
    /// </summary>
    public List<ActivityItem> correctItems;

    /// <summary>
    /// List with the incorrect activity items
    /// </summary>
    public List<ActivityItem> incorrectItems;

    /// <summary>
    /// List with the UI Match parent of the activity items
    /// </summary>
    public List<RectTransform> UIItems;

    /// <summary>
    /// Define the current number of correct items that select the user
    /// </summary>
    public int numOfCorrect = 0;

    /// <summary>
    /// Gameobjects that defines the turns of the players
    /// </summary>
    public GameObject[] turns;

    /// <summary>
    /// Container of all objects in game (necessary to hidde when recompensation appears)
    /// </summary>
    public GameObject inGameObjects;

    /// <summary>
    /// Container of all ui objects (necessary to hidde when recompensation appears)
    /// </summary>
    public GameObject inGameUIObjects;

    /// <summary>
    /// Trophy gameobject, this appear when activity is finish
    /// </summary>
    public GameObject trophy;

    /// <summary>
    /// White panel that create overlay effect in the scene, it's necessay to change alpha when recompensation appears
    /// </summary>
    public Image whitePanel;

    /// <summary>
    /// Object with tutorial information needed
    /// </summary>
    public Tutorial tutorialInfo;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        InitObjectPositions();
        if (turns.Length == 2)
        {
            SceneController sceneController = GameObject.FindGameObjectWithTag("Loader").GetComponent<SceneController>();

            if (sceneController.GetCurrentScene() != "Level 2 - Activity 1-1") { 
                turns[0].SetActive(true);
                turns[1].SetActive(false);
            }else{
                turns[1].SetActive(true);
                turns[0].SetActive(false);
            }
        }
        tutorialInfo = JsonUtility.FromJson<Tutorial>(PlayerPrefs.GetString("SelectedTutorial"));
    }

    /// <summary>
    /// Method to init the objects positions
    /// Positions are random, but all of correct items appear ever
    /// </summary>
    void InitObjectPositions()
    {
        List<ActivityItem> correctTemporal = new List<ActivityItem>(correctItems);
        List<ActivityItem> incorrectTemporal = new List<ActivityItem>(incorrectItems);

        List<Vector2> temporalPositions = new List<Vector2>(possiblePositions);
        List<Vector2> temporalUIPositions = new List<Vector2>(possibleUIPositions);


        for (int i = 0; i < numberOfItems; i++)
        {
            int indexPosition = Random.Range(0, temporalPositions.Count);
            if (correctTemporal.Count != 0)
            {
                correctTemporal[0].gameObject.SetActive(true);
                correctTemporal[0].gameObject.transform.position = new Vector3(temporalPositions[indexPosition].x, temporalPositions[indexPosition].y, 0);
                correctTemporal.RemoveAt(0);
            }
            else if (incorrectTemporal.Count != 0)
            {
                int indexIncorrect = Random.Range(0, incorrectTemporal.Count);
                incorrectTemporal[indexIncorrect].gameObject.SetActive(true);
                incorrectTemporal[indexIncorrect].gameObject.transform.position = new Vector3(temporalPositions[indexPosition].x, temporalPositions[indexPosition].y, 0);
                incorrectTemporal.RemoveAt(indexIncorrect);
            }
            else
            {
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

    /// <summary>
    /// Method to check if the user finish the activity
    /// If not, change the turn
    /// </summary>
    public void CheckIfFinish()
    {
        numOfCorrect++;
        if (numOfCorrect >= correctItems.Count)
        {
            if (turns.Length == 2)
            {
                turns[0].SetActive(false);
                turns[1].SetActive(false);
            }

            MainLevelController main = GameObject.FindGameObjectWithTag("LevelController").GetComponent<MainLevelController>();
            Tutorial tutorialInfo = JsonUtility.FromJson<Tutorial>(PlayerPrefs.GetString("SelectedTutorial"));

            SceneController sceneController = GameObject.FindGameObjectWithTag("Loader").GetComponent<SceneController>();
            
            if(sceneController.GetCurrentScene() != "Level 2 - Activity 1"){
                if (!main.levelData.currentTrophies.Contains(tutorialInfo.id))
                {
                    main.levelData.currentTrophies.Add(tutorialInfo.id);
                }

                main.progressBar.AddSection(true);
            }

            StartCoroutine(ChangeToPrincipal(main));
        }
        else
        {
            ChangeTurn();
        }
    }

    /// <summary>
    /// Method to change turn gameobject
    /// </summary>
    public void ChangeTurn()
    {
        if (turns.Length == 2 && turns[0].activeSelf)
        {
            turns[0].SetActive(false);
            turns[1].SetActive(true);
        }
        else if (turns.Length == 2)
        {
            turns[0].SetActive(true);
            turns[1].SetActive(false);
        }
    }

    /// <summary>
    /// Method to change scene to level principal 
    /// </summary>
    /// <param name="main">MainLevelController to save level data</param>
    /// <returns>Courutine</returns>
    IEnumerator ChangeToPrincipal(MainLevelController main)
    {
        SceneController sceneController = GameObject.FindGameObjectWithTag("Loader").GetComponent<SceneController>();
        yield return new WaitForSeconds(1f);

        if (sceneController.GetCurrentScene() != "Level 2 - Activity 1") {
            inGameObjects.SetActive(false);
            inGameUIObjects.SetActive(false); 
            whitePanel.color = new Color32(255, 255, 255, 0);
            trophy.SetActive(true);
        }else{
            main.SaveLevelData();
            sceneController.LoadScene("Level 2 - Activity 1-1");
        }

        yield return new WaitForSeconds(5f);

        if(sceneController.GetCurrentScene() != "Level 2 - Activity 1"){
            main.SaveLevelData();
            sceneController.LoadScene("Level " + main.levelData.level.numberLevel);
        }
    }
}
