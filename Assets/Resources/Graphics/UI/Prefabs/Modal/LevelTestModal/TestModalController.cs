using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestModalController : MonoBehaviour
{
    public SelectOptionsBehaviour selectOptionsBehaviour;
    public LevelTestModalRender levelTestModalRender;
    public int level;
    public int numberOfSimilarOptions;
    // Start is called before the first frame update
    void Start()
    {
        selectOptionsBehaviour.setup();
        levelTestModalRender.setup();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onCorrectAnswer(){
        Debug.Log("OOOOO correct answer");
    }

    public void onIncorrectAnswer(){
        Debug.Log("XXXXX Incorrect answer");

    }
}
