using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class for util methods
/// </summary>
public class Utils : MonoBehaviour
{
    /// <summary>
    /// Method to get limit int value
    /// </summary>
    /// <param name="value">Value to check if exceed limits</param>
    /// <param name="limit">Value of the limit to check</param>
    /// <returns>if the value passed is greater than limit, returns limit</returns>
    public static int GetLimit(int value, int limit){
        if(value > limit){
            return limit;
        }else{
            return value;
        }
    }

    /// <summary>
    /// Method to get censored email
    /// </summary>
    /// <param name="email">Email to censored</param>
    /// <returns>String with censored email</returns>
    public static string GetCensoredEmail(string email){
        string result = "";
        string[] splitEmail = email.Split('@');
        if(splitEmail.Length == 2){
            result += splitEmail[0].Substring(0, 3);
            for (int i = 0; i < Utils.GetLimit(splitEmail[0].Length - 3, 12); i++)
            {
                result += "*";
            }
            result += "@";

            string[] subSplitEmail = splitEmail[1].Split('.');
            if(subSplitEmail.Length == 2){
                result += subSplitEmail[0].Substring(0, 1);
                for (int i = 0; i < Utils.GetLimit(subSplitEmail[0].Length - 1, 7); i++)
                {
                    result += "*";
                }
                result += "." + subSplitEmail[1];
            }else{
                return "";
            }
            
        }else{
            return "";
        }

        return result;
    }

    /// <summary>
    /// Method to change second to formatted time
    /// </summary>
    /// <param name="time">Time in seconds</param>
    /// <returns>Formatted time</returns>
    public static string GetTimeFormatted(int time){
        TimeSpan t = TimeSpan.FromSeconds( time );
        string result = string.Format("{0:D1}h {1:D2}m {2:D2}s", 
                t.Hours, 
                t.Minutes, 
                t.Seconds, 
                t.Milliseconds);
        return result;
    }

    /// <summary>
    /// Method to get current date with necessary format
    /// </summary>
    /// <returns>Formatted date</returns>
    public static string GetCurrentDate(){
        return DateTime.Now.ToString("dd/MM/yyyy"); 
    }

    /// <summary>
    /// Method to get current hour with necessary format
    /// </summary>
    /// <returns>Formatted hour</returns>
    public static string GetCurrentHour(){
        return DateTime.Now.ToString("HH:mm");
    }

    /// <summary>
    /// Method that creates a random character
    /// </summary>
    /// <returns>Random character</returns>
    public static char CreateRandomLetter(){
        string st = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        char c = st[UnityEngine.Random.Range(0, st.Length)];
        return c;
    }

    /// <summary>
    /// Method to create random team name
    /// </summary>
    /// <returns>String with "Equipo" + "Random letter" + "Random number between [1 - 100)"</returns>
    public static string CreateRandomTeamName(){
        string name = "Equipo ";
        name += CreateRandomLetter();
        name += UnityEngine.Random.Range(1, 100);
        return name;
    }

    public static List<Tutorial> GetTutorials(){
        List<Tutorial> tutorials = new List<Tutorial>();

        Tutorial letterA = new Tutorial();
        letterA.isLetterTutorial = true;
        letterA.videoPath = "Vids/Tutorials/a";
        letterA.letterSprite = Resources.Load("Graphics/Levels/1/Letters/a", typeof(Sprite)) as Sprite;
        letterA.camPosition = new Vector3(4f, -0.5f, -10f);
        letterA.camProjection = 2.75f;
        letterA.activityScene = "Level 1 - Activity 1";
        letterA.id = 0;

        Tutorial letterE = new Tutorial();
        letterE.isLetterTutorial = true;
        letterE.videoPath = "Vids/Tutorials/e";
        letterE.letterSprite = Resources.Load("Graphics/Levels/1/Letters/e", typeof(Sprite)) as Sprite;
        letterE.camPosition = new Vector3(-3f, -0.5f, -10f);
        letterE.camProjection = 2.75f;
        letterE.activityScene = "Level 1 - Activity 2";
        letterE.id = 1;

        Tutorial letterO = new Tutorial();
        letterO.isLetterTutorial = true;
        letterO.videoPath = "Vids/Tutorials/o";
        letterO.letterSprite = Resources.Load("Graphics/Levels/1/Letters/o", typeof(Sprite)) as Sprite;
        letterO.camPosition = new Vector3(1.2f, -0.5f, -10f);
        letterO.camProjection = 2.75f;
        letterO.activityScene = "Level 1 - Activity 3";
        letterO.id = 2;

        tutorials.Add(letterA);
        tutorials.Add(letterE);
        tutorials.Add(letterO);

        return tutorials;
    }

    public static Tutorial GetTutorial(int index){
        Tutorial tutorial = Utils.GetTutorials()[index];

        return tutorial;
    }

    /// <summary>
    /// Create level data to start application first time
    /// </summary>
    public static void InitLevelsData(){
        List<Level> levels = new List<Level>();
        
        Level level1 = new Level();
        level1.numberLevel = 1;
        level1.isDifficultyVariant = false;
        level1.numberOfPlayers = 2;
        level1.numberOfItems = 6;
        level1.possibleMisstakes = 3;
        level1.barSections = 6;
        level1.numOfActivities = 3;

        Level level2 = new Level();
        level2.numberLevel = 2;
        level2.isDifficultyVariant = false;
        level2.numberOfPlayers = 2;
        level2.numberOfItems = 4;
        level2.possibleMisstakes = 2;
        level2.barSections = 4;
        level2.numOfActivities = 2;

        Level level3 = new Level();
        level3.numberLevel = 3;
        level3.isDifficultyVariant = true;
        level3.actualDifficult = 0;
        level3.numberOfPlayers = 1;
        level3.numberOfItems = 12;
        level3.possibleMisstakes = 5;
        level3.barSections = 6;
        level3.numOfActivities = 3;

        Level level4 = new Level();
        level4.numberLevel = 4;
        level4.isDifficultyVariant = true;
        level4.actualDifficult = 0;
        level4.numberOfPlayers = 2;
        level4.numberOfItems = 4;
        level4.possibleMisstakes = 2;
        level4.barSections = 4;
        level4.numOfActivities = 2;

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

    public static void SetPlayer(string playerParam, PlayerSpriteRenderer spriteContainer, SpriteRenderer iconContainer){
        Player player = JsonUtility.FromJson<Player>(PlayerPrefs.GetString(playerParam));
        spriteContainer.spriteRenderer.material = player.colorMaterial;
        if(iconContainer != null && player.icon != null){
            iconContainer.sprite = player.icon;
        }
        if(player.sex == "Boy"){
            if(spriteContainer.isBack){
                spriteContainer.spriteRenderer.sprite = Resources.Load("Graphics/UI/Pjs/Selector/BoyBack", typeof(Sprite)) as Sprite;
                spriteContainer.spriteRenderer.material.SetTexture("_MainText", Resources.Load("Graphics/UI/Pjs/Selector/BoyBack", typeof(Texture)) as Texture);
            }else{
                spriteContainer.spriteRenderer.sprite = Resources.Load("Graphics/UI/Pjs/Selector/Boy", typeof(Sprite)) as Sprite;
            }
        }else{
            if(spriteContainer.isBack){
                spriteContainer.spriteRenderer.sprite = Resources.Load("Graphics/UI/Pjs/Selector/GirlBack", typeof(Sprite)) as Sprite;
                spriteContainer.spriteRenderer.material.SetTexture("_MainText", Resources.Load("Graphics/UI/Pjs/Selector/GirlBack", typeof(Texture)) as Texture);
            }else{
                spriteContainer.spriteRenderer.sprite = Resources.Load("Graphics/UI/Pjs/Selector/Girl", typeof(Sprite)) as Sprite;
            }
        }
    }

    public static void SetIcons(string playerParam, SpriteRenderer[] SpriteRenderer){
        Player player = JsonUtility.FromJson<Player>(PlayerPrefs.GetString(playerParam));
        if(SpriteRenderer.Length > 0 && player.icon != null){
            foreach (SpriteRenderer spriteRender in SpriteRenderer)
            {
                spriteRender.sprite = player.icon;
            }
        }
        
    }

    public static void SetPlayer(string playerParam, Image spriteContainer, Image iconContainer){
        Player player = JsonUtility.FromJson<Player>(PlayerPrefs.GetString(playerParam));
        spriteContainer.material = player.colorMaterial;
        iconContainer.sprite = player.icon;
        if(player.sex == "Boy"){
            spriteContainer.sprite = Resources.Load("Graphics/UI/Pjs/Selector/Boy", typeof(Sprite)) as Sprite;
        }else{
            spriteContainer.sprite = Resources.Load("Graphics/UI/Pjs/Selector/Girl", typeof(Sprite)) as Sprite;
        }
    }
}
