using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLevelController : MonoBehaviour
{
    public StarsController starsController;
    public FeedBackUI progressBar;
    public BackpackController backpack;
    public LevelData levelData;
    public bool inModal = false;

    private void Awake() {
        ReadLevelData();

        starsController.currentCorrect = levelData.currentCorrect;
        starsController.currentMisstakes = levelData.currentMisstakes;
        starsController.startPosition = levelData.starsPosition;
        starsController.numOfItems = levelData.level.numberOfItems;
        starsController.possibleMisstakes = levelData.level.possibleMisstakes;

        progressBar.sections = levelData.level.barSections;
        progressBar.currentSection = levelData.barCurrentSection;

        backpack.currentTrophys = levelData.currentTrophys;
    }

    void ReadLevelData() {
        string jsonData = PlayerPrefs.GetString("levelData");
        if(jsonData == null || jsonData == ""){
            levelData = CreateLevelData();
            PlayerPrefs.SetString("levelData", JsonUtility.ToJson(levelData));
        }else{
            levelData = JsonUtility.FromJson<LevelData>(jsonData);
        }
    }

    LevelData CreateLevelData() {
        LevelData data = new LevelData();
        data.currentTrophys = new List<int>();
        Player player1 = JsonUtility.FromJson<Player>(PlayerPrefs.GetString("player1"));

        data.players = new List<Player>();
        data.players.Add(player1);

        string player2Json = PlayerPrefs.GetString("player2");
        if(player2Json != null && player2Json != ""){
            Player player2 = JsonUtility.FromJson<Player>(player2Json);
            data.players.Add(player2);
        }

        data.level = JsonUtility.FromJson<Level>(PlayerPrefs.GetString("Levels"));
        data.currentMisstakes = 0;
        data.currentCorrect = 0;
        data.starsPosition = 280;
        data.barCurrentSection = 0;
        data.time = 0;
        data.date = Utils.GetCurrentDate();
        data.hour = Utils.GetCurrentHour();
        return data;
    }

    // Update is called once per frame
    void Update()
    {
        MouseRaycast();
    }

    void MouseRaycast(){
        if (Input.GetMouseButtonDown(0) && !inModal){
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
 
            if(hit.collider != null)
            {
                Debug.Log ("Target Position: " + hit.collider.gameObject.transform.position);
            }
        }
    }
}
