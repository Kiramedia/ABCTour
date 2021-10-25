using UnityEngine.UI;
using UnityEngine;

public class SelectGender : MonoBehaviour
{
    public int player = 1;
    public GameObject boyPrefab;
    public GameObject girlPrefab;
    private string gender;
    public CharacterController characterController;

    private GameObject currentCharacter;

    public Player playerInfo;
    // Start is called before the first frame update
    void Start()
    {
        playerInfo = JsonUtility.FromJson<Player>(PlayerPrefs.GetString("player1"));
        setGender(playerInfo.sex);
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

        Utils.SetPlayer("player" + player, currentCharacter.GetComponent<Image>(), currentCharacter.transform.GetChild(0).GetComponent<Image>());
        characterController.characterEmotionController = currentCharacter.GetComponent<CharacterEmotionController>();
    }
}
