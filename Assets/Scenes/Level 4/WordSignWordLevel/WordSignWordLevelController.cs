using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WordSignWordLevelController : MonoBehaviour
{
    public int level;
    public List<SignWord> availableWords;
    public SignWord correctSignWords;
    public List<SignWord> incorrectSignWords;
    public float maxTime;
    public float numberOfOptions;
    public bool isAnsweredCorrectly;
    public GameObject selectWordModal;
    public GameObject wordModal;

    public GameObject timeChange;

    public GameObject selectWordPrefab;
    public GameObject wordModalPrefab;

    public GameObject[] turns;
    private int actTurn = 1;

    private int numberOfAnswers = 0;

    private int numberOfMistakes = 0;

    public CharacterController characterPlayer1;
    public CharacterController characterPlayer2;

    private MainLevelController main;

    public GameObject panel;
    public GameObject Trophy;
    public GameObject Misstake;

    // Start is called before the first frame update
    void Start()
    {
        if(GameObject.FindGameObjectWithTag("LevelController") != null){
            main = GameObject.FindGameObjectWithTag("LevelController").GetComponent<MainLevelController>();
            level = PlayerPrefs.GetInt("selectedDifficult") + 1;
        }

        selectTimeAndNumberOfOptions();
        SetPlayerPosition(1);
        Init();
    }

    void Init(){
        selectOptions();
        selectWordModal.GetComponent<SelectWordModalController>().renderButtons();
        selectWordModal.GetComponent<SelectWordModalController>().maxTime = maxTime;
        wordModal.GetComponent<WordModalController>().setup();
        wordModal.SetActive(true);
        selectWordModal.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SetPlayerPosition(int turn){
        if(turn == 1){
            characterPlayer1.onHappy();
            characterPlayer2.onBack();
            turns[0].SetActive(true);
            turns[1].SetActive(false);
            actTurn = 1;
        } else{
            characterPlayer2.onHappy();
            characterPlayer1.onBack();
            turns[0].SetActive(false);
            turns[1].SetActive(true);
            actTurn = 2;
        }
    }

    public void selectTimeAndNumberOfOptions()
    {
        switch (level)
        {
            case 1:
                numberOfOptions = 3;
                maxTime = 120;
                break;
            case 2:
                numberOfOptions = 6;
                maxTime = 120;
                break;
            case 3:
                numberOfOptions = 6;
                maxTime = 60;
                break;

            default:
                numberOfOptions = 3;
                maxTime = 120;
                break;
        }
    }

    public void selectOptions()
    {
        incorrectSignWords = new List<SignWord>();

        System.Random random = new System.Random();
        int randomNumber = random.Next(0, availableWords.Count);
        correctSignWords = RemoveAndGet(availableWords, randomNumber);
        List<SignWord> temporalAvailableWords = availableWords.ToList();

        for (int i = 0; i < numberOfOptions - 1; i++)
        {
            random = new System.Random();
            randomNumber = random.Next(0, temporalAvailableWords.Count);
            incorrectSignWords.Add(RemoveAndGet(temporalAvailableWords, randomNumber));
        }
    }

    public T RemoveAndGet<T>(IList<T> list, int index)
    {
        lock (list)
        {
            T value = list[index];
            list.RemoveAt(index);
            return value;
        }
    }

    public void changeQuestion(){
        timeChange.SetActive(false);
        GameObject duplicate1 = Instantiate(selectWordPrefab, selectWordModal.transform.parent);
        GameObject duplicate2 = Instantiate(wordModalPrefab, wordModal.transform.parent);
        Destroy(selectWordModal);
        selectWordModal = duplicate1;
        Destroy(wordModal);
        wordModal = duplicate2;
        Init();
    }

    //when test answered correctly
    public void onCorrectAnswer()
    {
        if(main != null){
            main.starsController.CorrectAnswer();
        }

        isAnsweredCorrectly = true;
        onQuestionAnswered();

        characterPlayer1.onCorrectAnswer();
        characterPlayer2.onCorrectAnswer();
    }

    //when test answered incorrectly
    public void onIncorrectAnswer()
    {
        if(main != null){
            main.starsController.IncorrectAnswer();
        }

        isAnsweredCorrectly = false;
        selectWordModal.GetComponent<SelectWordModalController>().onAnswer();
        onQuestionAnswered();

        characterPlayer1.onIncorrectAnswer();
        characterPlayer2.onIncorrectAnswer();
    }

    private void onQuestionAnswered()
    {
        numberOfAnswers++;
        if(numberOfAnswers < 2){
            StartCoroutine(onAnswered());
        } else{
            onLevelFinish();
        }
    }

    IEnumerator onAnswered(){
        yield return new WaitForSeconds(2f);
        selectWordModal.SetActive(false);
        wordModal.SetActive(false);
        timeChange.SetActive(true);
        SetPlayerPosition(2);
    }

    //when level finishes
    public void onLevelFinish()
    {
        Tutorial tutorialInfo = JsonUtility.FromJson<Tutorial>(PlayerPrefs.GetString("SelectedTutorial"));
        if (!main.levelData.currentTrophies.Contains(tutorialInfo.id))
        {
            main.levelData.currentTrophies.Add(tutorialInfo.id);
        }

        main.progressBar.AddSection(true);

        if (numberOfMistakes > 0)
        {

            if (!main.levelData.misstakesTrophies.Contains(tutorialInfo.id))
            {
                main.levelData.misstakesTrophies.Add(tutorialInfo.id);
            }
            Misstake.SetActive(true);
        }
        else
        {
            Misstake.SetActive(false);
        }

        StartCoroutine(ChangeToPrincipal(main));
    }

    public void onWordModalButtonPressed(){
        selectWordModal.SetActive(true);
        characterPlayer1.onNeutral();
        characterPlayer2.onNeutral();
        if(actTurn == 1){
            actTurn = 2;
            turns[0].SetActive(false);
            turns[1].SetActive(true);
        } else{
            actTurn = 1;
            turns[0].SetActive(true);
            turns[1].SetActive(false);
        }
    }

    /// <summary>
    /// Method to change scene to level principal 
    /// </summary>
    /// <param name="main">MainLevelController to save level data</param>
    /// <returns>Courutine</returns>
    IEnumerator ChangeToPrincipal(MainLevelController main)
    {
        characterPlayer1.onHappy();
        characterPlayer2.onHappy();
        SceneController sceneController = GameObject.FindGameObjectWithTag("Loader").GetComponent<SceneController>();
        yield return new WaitForSeconds(1f);

        panel.SetActive(false);
        Trophy.SetActive(true);

        yield return new WaitForSeconds(5f);

        main.SaveLevelData();
        sceneController.LoadScene("Level " + main.levelData.level.numberLevel);
    }
}
