using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Main class that control all level functions
/// This is the core of levels behaviour
/// </summary>
public class MainLevelController : MonoBehaviour
{

    /// <summary>
    /// Start controller of the level
    /// </summary>
    public StarsController starsController;

    /// <summary>
    /// Progress bar controller of the level
    /// </summary>
    public FeedBackUI progressBar;

    /// <summary>
    /// Backpack controller of the level
    /// </summary>
    public BackpackController backpack;

    /// <summary>
    /// Object with all important level data
    /// </summary>
    public LevelData levelData;

    /// <summary>
    /// Define if level is in modal to change some behaviors
    /// </summary>
    public bool inModal = false;

    /// <summary>
    /// Define if the player completed all the activities
    /// </summary>
    public bool isFinish = false;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        ReadLevelData();

        starsController.currentCorrect = levelData.currentCorrect;
        starsController.currentMisstakes = levelData.currentMisstakes;
        starsController.startPosition = levelData.starsPosition;
        starsController.numOfItems = levelData.level.numberOfItems;
        starsController.possibleMisstakes = levelData.level.possibleMisstakes;

        progressBar.sections = levelData.level.barSections;
        progressBar.currentSection = levelData.barCurrentSection;
        backpack.currentTrophies = levelData.currentTrophies;
        backpack.misstakeTrophies = levelData.misstakesTrophies;

        if (levelData.currentTrophies.Count == levelData.level.numOfActivities)
        {
            isFinish = true;

            if (levelData.emailWasSend == false)
            {
                levelData.emailWasSend = true;
                SaveLevelData();
                SaveCalification(levelData);
                EmailManager.Send(levelData);
            }
        }
    }

    /// <summary>
    /// Method to get level data if exists, in case that not, create the data
    /// </summary>
    void ReadLevelData()
    {
        string jsonData = PlayerPrefs.GetString("levelData");
        if (jsonData == null || jsonData == "")
        {
            levelData = CreateLevelData();
            PlayerPrefs.SetString("levelData", JsonUtility.ToJson(levelData));
        }
        else
        {
            levelData = JsonUtility.FromJson<LevelData>(jsonData);
        }
    }

    /// <summary>
    /// Method to create level data if not exist
    /// </summary>
    /// <returns>Level data</returns>
    LevelData CreateLevelData()
    {
        LevelData data = new LevelData();
        data.currentTrophies = new List<int>();
        data.misstakesTrophies = new List<int>();
        Player player1 = JsonUtility.FromJson<Player>(PlayerPrefs.GetString("player1"));

        data.players = new List<Player>();
        data.players.Add(player1);

        string player2Json = PlayerPrefs.GetString("player2");
        if (player2Json != null && player2Json != "")
        {
            Player player2 = JsonUtility.FromJson<Player>(player2Json);
            data.players.Add(player2);
        }

        data.level = JsonUtility.FromJson<Level>(PlayerPrefs.GetString("selectedLevel"));
        data.currentMisstakes = 0;
        data.currentCorrect = 0;
        data.starsPosition = 280;
        data.barCurrentSection = 0;
        data.time = 0;
        data.date = Utils.GetCurrentDate();
        data.hour = Utils.GetCurrentHour();
        data.emailWasSend = false;
        return data;
    }

    /// <summary>
    /// Method to save level data in the player prefs
    /// </summary>
    public void SaveLevelData()
    {
        if (!isFinish)
        {
            levelData.currentCorrect = starsController.currentCorrect;
            levelData.currentMisstakes = starsController.currentMisstakes;
            levelData.starsPosition = starsController.startPosition;
            levelData.barCurrentSection = progressBar.currentSection;
            PlayerPrefs.SetString("levelData", JsonUtility.ToJson(levelData));
        }
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        MouseRaycast();
        levelData.time += Time.deltaTime;
    }

    /// <summary>
    /// Method to called in update to check mouse raycast and make some actions depends of the collider hitted
    /// </summary>
    void MouseRaycast()
    {
        if (Input.GetMouseButtonDown(0) && !inModal)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.collider.gameObject.transform.name.Contains("letter") || hit.collider.gameObject.transform.name.Contains("sign"))
                {
                    switch (hit.collider.gameObject.transform.name)
                    {
                        case "a letter":
                            PlayerPrefs.SetString("SelectedTutorial", JsonUtility.ToJson(Utils.GetTutorial(0)));
                            GameObject.FindGameObjectWithTag("Loader").GetComponent<SceneController>().LoadScene("Level 1 - Tutorial");
                            break;
                        case "e letter":
                            PlayerPrefs.SetString("SelectedTutorial", JsonUtility.ToJson(Utils.GetTutorial(1)));
                            GameObject.FindGameObjectWithTag("Loader").GetComponent<SceneController>().LoadScene("Level 1 - Tutorial");
                            break;
                        case "o letter":
                            PlayerPrefs.SetString("SelectedTutorial", JsonUtility.ToJson(Utils.GetTutorial(2)));
                            GameObject.FindGameObjectWithTag("Loader").GetComponent<SceneController>().LoadScene("Level 1 - Tutorial");
                            break;
                        case "m letter":
                            PlayerPrefs.SetString("SelectedTutorial", JsonUtility.ToJson(Utils.GetTutorial(3)));
                            GameObject.FindGameObjectWithTag("Loader").GetComponent<SceneController>().LoadScene("Level 2 - Tutorial");
                            break;
                        case "p letter":
                            PlayerPrefs.SetString("SelectedTutorial", JsonUtility.ToJson(Utils.GetTutorial(4)));
                            GameObject.FindGameObjectWithTag("Loader").GetComponent<SceneController>().LoadScene("Level 2 - Tutorial");
                            break;
                        case "sign 3-1":
                            PlayerPrefs.SetString("SelectedTutorial", JsonUtility.ToJson(Utils.GetTutorial(5)));
                            GameObject.FindGameObjectWithTag("Loader").GetComponent<SceneController>().LoadScene("Level 3 - Tutorial");
                            break;
                        case "sign 3-2":
                            PlayerPrefs.SetString("SelectedTutorial", JsonUtility.ToJson(Utils.GetTutorial(6)));
                            GameObject.FindGameObjectWithTag("Loader").GetComponent<SceneController>().LoadScene("Level 3 - Tutorial");
                            break;
                        case "sign 3-3":
                            PlayerPrefs.SetString("SelectedTutorial", JsonUtility.ToJson(Utils.GetTutorial(7)));
                            GameObject.FindGameObjectWithTag("Loader").GetComponent<SceneController>().LoadScene("Level 3 - Tutorial");
                            break;
                        case "sign 4-1":
                            PlayerPrefs.SetString("SelectedTutorial", JsonUtility.ToJson(Utils.GetTutorial(8)));
                            GameObject.FindGameObjectWithTag("Loader").GetComponent<SceneController>().LoadScene("Level 4 - Tutorial");
                            break;
                        case "sign 4-2":
                            PlayerPrefs.SetString("SelectedTutorial", JsonUtility.ToJson(Utils.GetTutorial(9)));
                            GameObject.FindGameObjectWithTag("Loader").GetComponent<SceneController>().LoadScene("Level 4 - Tutorial");
                            break;
                        default:
                            break;
                    }
                }
                else if (hit.collider.gameObject.transform.name.Contains("ActivityItem"))
                {
                    ActivityItem activityItem = hit.collider.gameObject.GetComponentInParent<ActivityItem>();
                    activityItem.SetAnswer();

                    GameObject ballsSystem = GameObject.Find("BallSystem");
                    if (ballsSystem != null)
                    {
                        ballsSystem.GetComponent<BallsSystem>().DisappearBall();
                    }
                }
                else if (hit.collider.gameObject.transform.name.Equals("BusLevel"))
                {
                    GameObject.FindGameObjectWithTag("Loader").GetComponent<SceneController>().LoadScene("Start - Levels");
                }
            }
        }
    }

    /// <summary>
    /// Method to save calification information in player prefs
    /// </summary>
    /// <param name="data">Level data necessary to make calification</param>
    void SaveCalification(LevelData data)
    {
        CalificationCollection collection = JsonUtility.FromJson<CalificationCollection>(PlayerPrefs.GetString("Calification"));

        Calification newCalification = new Calification();
        newCalification.level = data.level.numberLevel;
        newCalification.date = data.date;
        newCalification.teamName = PlayerPrefs.GetString("Device");
        newCalification.misstakes = data.currentMisstakes;
        newCalification.time = Utils.GetTimeFormatted((int)data.time);
        newCalification.hour = data.hour;

        List<Calification> califications = new List<Calification>(collection.califications);

        if (califications.Count >= data.level.numberLevel)
        {
            califications[data.level.numberLevel - 1] = newCalification;
        }

        collection.califications = califications.ToArray();
        PlayerPrefs.SetString("Calification", JsonUtility.ToJson(collection));

        int actLevel = PlayerPrefs.GetInt("actLevelAvalaible");
        if (actLevel == data.level.numberLevel)
        {
            PlayerPrefs.SetInt("actLevelAvalaible", data.level.numberLevel + 1);
        }

        if(data.level.isDifficultyVariant){
            Level[] levels = JsonUtility.FromJson<LevelCollection>(PlayerPrefs.GetString("Levels")).levels;

            if(levels[data.level.numberLevel - 1].actualDifficult < 2){
                levels[data.level.numberLevel - 1].actualDifficult += 1;
            }

            LevelCollection levelCollection = new LevelCollection();
            levelCollection.levels = levels;

            PlayerPrefs.SetString("Levels", JsonUtility.ToJson(levelCollection));
        }
    }
}
