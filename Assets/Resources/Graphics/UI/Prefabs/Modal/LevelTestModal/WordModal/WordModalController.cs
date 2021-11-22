using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordModalController : MonoBehaviour
{
    public Text upperCaseText;
    public Text lowerCaseText;
    public string text;
    public WordSignWordLevelController wordSignWordLevelController;
    // Start is called before the first frame update
    void Start()
    {
        setup();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setup()
    {
        if(wordSignWordLevelController == null){
            GameObject levelController = GameObject.FindGameObjectWithTag("LevelController");
            if(levelController != null){
                wordSignWordLevelController = levelController.GetComponent<WordSignWordLevelController>();
            }
        }

        text = wordSignWordLevelController.correctSignWords.word;
        text = text.ToLower();

        upperCaseText.text = text.ToUpper();

        lowerCaseText.text = text;
    }

    public void OnButtonPressed()
    {
        wordSignWordLevelController.onWordModalButtonPressed();
        this.gameObject.SetActive(false);
    }
}
