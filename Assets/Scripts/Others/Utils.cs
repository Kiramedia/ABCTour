using UnityEngine;

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
        result += splitEmail[0].Substring(0, 3);
        for (int i = 0; i < Utils.GetLimit(splitEmail[0].Length - 3, 12); i++)
        {
            result += "*";
        }
        result += "@";

        string[] subSplitEmail = splitEmail[1].Split('.');
        result += subSplitEmail[0].Substring(0, 1);
        for (int i = 0; i < Utils.GetLimit(subSplitEmail[0].Length - 1, 7); i++)
        {
            result += "*";
        }
        result += "." + subSplitEmail[1];

        return result;
    }
}
