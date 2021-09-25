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
        letterA.letterSprite = Resources.Load("Graphics/Backgrounds/Level 1/Letters/a", typeof(Sprite)) as Sprite;
        letterA.camPosition = new Vector3(4f, -0.5f, -10f);
        letterA.camProjection = 2.75f;

        Tutorial letterE = new Tutorial();
        letterE.isLetterTutorial = true;
        letterE.videoPath = "Vids/Tutorials/e";
        letterE.letterSprite = Resources.Load("Graphics/Backgrounds/Level 1/Letters/e", typeof(Sprite)) as Sprite;
        letterE.camPosition = new Vector3(-3f, -0.5f, -10f);
        letterE.camProjection = 2.75f;

        Tutorial letterO = new Tutorial();
        letterO.isLetterTutorial = true;
        letterO.videoPath = "Vids/Tutorials/o";
        letterO.letterSprite = Resources.Load("Graphics/Backgrounds/Level 1/Letters/o", typeof(Sprite)) as Sprite;
        letterO.camPosition = new Vector3(1.2f, -0.5f, -10f);
        letterO.camProjection = 2.75f;

        tutorials.Add(letterA);
        tutorials.Add(letterE);
        tutorials.Add(letterO);

        return tutorials;
    }

    public static Tutorial GetTutorial(int index){
        Tutorial tutorial = Utils.GetTutorials()[index];

        return tutorial;
    }

    public static void SetPlayer(string playerParam, SpriteRenderer spriteContainer, SpriteRenderer iconContainer){
        Player player = JsonUtility.FromJson<Player>(PlayerPrefs.GetString(playerParam));
        spriteContainer.material = player.colorMaterial;
        iconContainer.sprite = player.icon;
        if(player.sex == "Boy"){
            spriteContainer.sprite = Resources.Load("Graphics/UI/Pjs/Selector/Boy", typeof(Sprite)) as Sprite;
        }else{
            spriteContainer.sprite = Resources.Load("Graphics/UI/Pjs/Selector/Girl", typeof(Sprite)) as Sprite;
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
