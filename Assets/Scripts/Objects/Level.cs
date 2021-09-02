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
    /// Serialize information in String
    /// </summary>
    public new string ToString => "Nivel: " + numberLevel
        + "\nTiene dificultades: " + isDifficultyVariant
        + "\nDificultad actual: " + actualDifficult;

}

/// <summary>
/// Level collection
/// </summary>
[Serializable]
public class LevelCollection{
    /// <summary>
    /// Level array
    /// </summary>
    public Level[] levels;
}