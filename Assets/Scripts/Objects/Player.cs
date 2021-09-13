using System;
using UnityEngine;

/// <summary>
/// Player object
/// </summary>
[Serializable]
public class Player
{
    /// <summary>
    /// Color player selected
    /// </summary>
    public Material colorMaterial;

    /// <summary>
    /// Sprite icon selected
    /// </summary>
    public Sprite icon;

    /// <summary>
    /// Sex player selected
    /// </summary>
    public string sex;

    /// <summary>
    /// Serialize information in String
    /// </summary>
    public new string ToString => "Sexo: " + sex
        + "\nColor: " + colorMaterial
        + "\nSprite: " + icon;

}