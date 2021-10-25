using System;
using System.Collections.Generic;

/// <summary>
/// Level data object
/// </summary>
[Serializable]
public class LevelData
{
    /// <summary>
    /// List with trophies won by the user
    /// </summary>
    public List<int> currentTrophies;

    /// <summary>
    /// List with trophies won level 3-4 when misstakes
    /// </summary>
    public List<int> misstakesTrophies;

    /// <summary>
    /// List of the players that have the level
    /// </summary>
    public List<Player> players;

    /// <summary>
    /// Level information
    /// </summary>
    public Level level;

    /// <summary>
    /// User current misstakes
    /// </summary>
    public int currentMisstakes;

    /// <summary>
    /// User current correct answers
    /// </summary>
    public int currentCorrect;

    /// <summary>
    /// Stars position system
    /// </summary>
    public float starsPosition;

    /// <summary>
    /// Progress bar current section
    /// </summary>
    public int barCurrentSection;

    /// <summary>
    /// Time in the level experience
    /// </summary>
    public float time;

    /// <summary>
    /// Current data when level start
    /// </summary>
    public string date;

    /// <summary>
    /// Current hour when level start
    /// </summary>
    public string hour;

    /// <summary>
    /// Define if email was send when user finish all the activities
    /// </summary>
    public bool emailWasSend;
}
