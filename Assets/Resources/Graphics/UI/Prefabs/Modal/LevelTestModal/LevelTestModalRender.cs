using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LevelTestModalRender : MonoBehaviour
{
    public SelectOptionsBehaviour selectOptionsBehaviour;
    public TestModalController testModalController;
    public GameObject answerOptions;
    public GameObject optionButtonPrefab;
    public List<float> widthsByLevel;

    public abstract void setup();
}
