using System;
using System.Collections.Generic;

[Serializable]
public class LevelData
{
    public List<int> currentTrophys;
    public List<Player> players;
    public Level level;
    public int currentMisstakes;
    public int currentCorrect;
    public float starsPosition;
    public int barCurrentSection;
    public float time;
    public string date;
    public string hour;
    public bool emailWasSend;
}
