using System;

/// <summary>
/// Level object
/// </summary>
[Serializable]
public class Level
{
    /// <summary>
    /// Level number
    /// </summary>
    public int numberLevel;

    /// <summary>
    /// Difficulty boolean
    /// </summary>
    public bool isDifficultyVariant;

    /// <summary>
    /// Actual difficult number if exist difficults for the level
    /// </summary>
    public int actualDifficult;

    /// <summary>
    /// Number of players for the level - max 2 players
    /// </summary>
    public int numberOfPlayers;

    /// <summary>
    /// Number of items in the level
    /// </summary>
    public int numberOfItems;

    /// <summary>
    /// Possible misstakes for the level
    /// </summary>
    public int possibleMisstakes;

    /// <summary>
    /// Number of sections for the progress bar
    /// </summary>
    public int barSections;

    /// <summary>
    /// Number of activities in the level
    /// </summary>
    public int numOfActivities;
}

/// <summary>
/// Level collection
/// </summary>
[Serializable]
public class LevelCollection
{
    /// <summary>
    /// Level array
    /// </summary>
    public Level[] levels;
}