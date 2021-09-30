using System;

/// <summary>
/// Calification object
/// </summary>
[Serializable]
public class Calification
{
    /// <summary>
    /// Level number
    /// </summary>
    public int level;

    /// <summary>
    /// Name of the device/student team
    /// </summary>
    public string teamName;

    /// <summary>
    /// Number of misstakes registered by the student(s)
    /// </summary>
    public int misstakes;

    /// <summary>
    /// Time taken by the student(s) to reach the level
    /// </summary>
    public string time;

    /// <summary>
    /// Date when the level was complete
    /// </summary>
    public string date;

    /// <summary>
    /// Hour when the level start
    /// </summary>
    public string hour;

    /// <summary>
    /// Serialize information in String
    /// </summary>
    public new string ToString => "Nivel: " + level
        + "\nNombre del equipo: " + teamName
        + "\nNúmero de fallos: " + misstakes
        + "\nTiempo realizado: " + time
        + "\nFecha de realización: " + date
        + "\nHora  de realización: " + hour;

}

/// <summary>
/// Calification collection
/// </summary>
[Serializable]
public class CalificationCollection
{
    /// <summary>
    /// Calification array
    /// </summary>
    public Calification[] califications;
}