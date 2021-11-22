using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterEmotionController : MonoBehaviour
{
    public Sprite neutralSprite; 
    public Sprite happySprite; 
    public Sprite sadSprite;
    public Sprite backSprite;
    public Image image;
    public GameObject iconImage;
    public float waitTime; 
    public bool test; 
    // Start is called before the first frame update
    void Start()
    {
        image.sprite = neutralSprite; 
    }

    // Update is called once per frame
    void Update()
    {

        if (test)
        {
            onCorrectAnswer();
            test = false; 
        } 
    }
    public void onCorrectAnswer()
    {
        StartCoroutine("happy");
    }
    public void onIncorrectAnswer()
    {
        StartCoroutine("sad");
    }

    public void onHappy(){
        iconImage.SetActive(true);
        image.sprite = happySprite;
        image.material.SetTexture("_MainText", happySprite.texture);
    }

    public void onBack(){
        iconImage.SetActive(false);
        image.sprite = backSprite;
        image.material.SetTexture("_MainText", backSprite.texture);
    }

    public void onNeutral(){
        iconImage.SetActive(true);
        image.sprite = neutralSprite;
        image.material.SetTexture("_MainText", neutralSprite.texture);
    }

    IEnumerator happy()
    {
        image.sprite = happySprite;
        image.material.SetTexture("_MainText", happySprite.texture);
        iconImage.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        image.sprite = neutralSprite;
        image.material.SetTexture("_MainText", neutralSprite.texture);
    }
    IEnumerator sad()
    {
        image.sprite = sadSprite; 
        image.material.SetTexture("_MainText", sadSprite.texture);
        iconImage.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        image.sprite = neutralSprite; 
        image.material.SetTexture("_MainText", neutralSprite.texture);
    }
}
