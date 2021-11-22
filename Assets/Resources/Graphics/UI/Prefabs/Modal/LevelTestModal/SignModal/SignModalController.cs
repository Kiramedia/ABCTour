using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignModalController : MonoBehaviour
{
    public Image signImage;
    public Sprite signSprite;
    public SignWordSignLevelController signWordSignLevelController;
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
        if(signWordSignLevelController == null){
            GameObject levelController = GameObject.FindGameObjectWithTag("LevelController");
            if(levelController != null){
                signWordSignLevelController = levelController.GetComponent<SignWordSignLevelController>();
            }
        }

        signSprite = signWordSignLevelController.correctSignWords.signs;

        signImage.sprite = signSprite;
    }
    public void OnButtonPressed()
    {
        signWordSignLevelController.onWordModalButtonPressed();
        this.gameObject.SetActive(false);
    }
}
