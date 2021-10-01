using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour
{
    public Sprite neutralSprite; 
    public Sprite happySprite; 
    public Sprite sadSprite; 
    public Image image; 
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
    IEnumerator happy()
    {
        image.sprite = happySprite; 
        yield return new WaitForSeconds(waitTime);
        image.sprite = neutralSprite; 
    }
    IEnumerator sad()
    {
        image.sprite = sadSprite; 
        yield return new WaitForSeconds(waitTime);
        image.sprite = neutralSprite; 
    }
}
