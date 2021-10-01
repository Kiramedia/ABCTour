using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectGender : MonoBehaviour
{
    public GameObject boyPrefab;
    public GameObject girlPrefab;
    public string gender;
    public CharacterController characterController;

    private GameObject currentCharacter; 
    // Start is called before the first frame update
    void Start()
    {
        selectGender();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setGender(string gender)
    {
        this.gender = gender; 

        selectGender();
    }

    public void selectGender()
    {
        if (gender == "Girl")
        {
            renderCharacter(girlPrefab);
        }
        else
        {
            renderCharacter(boyPrefab);
        }
    }

    public void renderCharacter(GameObject prefab)
    {
        Destroy(currentCharacter); 

        currentCharacter = Instantiate(prefab, this.transform) as GameObject; 

        characterController.characterEmotionController = currentCharacter.GetComponent<CharacterEmotionController>();
    }
}
