using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SelectMemoryOptions : MonoBehaviour
{
    public int numberOfOptions;
    public Abecedary levelSigns;
    public Abecedary abecedary;
    public GameObject memoryCardParent;
    public GameObject letterMemoryCardPrefab;
    public GameObject signMemoryCardPrefab;

    public List<Sign> optionsSigns;
    public List<GameObject> optionsGameObjects;
    public MemoryLevelBehaviour memoryLevelBehaviour;

    private bool coroutineFlag = true;

    // Start is called before the first frame update
    void Start()
    {
        selectOptions();

        renderOptions();
    }

    // Update is called once per frame
    void Update()
    {
        List<GameObject> selectedOptions = optionsGameObjects.Where(signGameObject =>
            (signGameObject.GetComponent<MemoryCardBehavior>().isSelected && !signGameObject.GetComponent<MemoryCardBehavior>().isCompleted)
        ).ToList();

        if(selectedOptions.Count > 1){
            Sign sign = selectedOptions[0].GetComponent<MemoryCardBehavior>().sign;
            
            List<GameObject> selectedLetterSigns = selectedOptions.Where(signGameObject =>
                (signGameObject.GetComponent<MemoryCardBehavior>().sign.letter == sign.letter)
            ).ToList();

            if(selectedLetterSigns.Count > 1){
                onCorrectAnswer();
                selectedLetterSigns.ForEach((selectedLetterSign) => {
                    selectedLetterSign.GetComponent<MemoryCardBehavior>().isCompleted = true;
                });
            }
            else if(coroutineFlag){
                coroutineFlag = false;
                onIncorrectAnswer();
            }

            StartCoroutine("coverAll");
        }

        if(optionsGameObjects.All((option) => option.GetComponent<MemoryCardBehavior>().isCompleted)){
            onGameWon();
        }
    }

    public void selectOptions()
    {
        int numberOfOptions = selectNumberOfOptions();

        List<Sign> temporalLevelSigns = levelSigns.signs.ToList();
        List<Sign> temporalAbecedary = abecedary.signs.ToList();

        optionsSigns = new List<Sign>();

        int numberOfSimilarOptions = 5;
        optionsSigns.AddRange(selectOptions(ref temporalLevelSigns, numberOfSimilarOptions));

        //List to remove from abecedary
        List<Sign> listToRemove = new List<Sign>(optionsSigns);

        temporalAbecedary = temporalAbecedary.Except(listToRemove).ToList();

        int numberOfDifferentOptions = 1;

        optionsSigns.AddRange(selectOptions(ref temporalAbecedary, numberOfDifferentOptions));
    }

    public void renderOptions()
    {
        optionsSigns.ForEach((sign) =>
        {
            // render letter card
            letterMemoryCardPrefab.GetComponent<MemoryCardBehavior>().sign = sign;
            GameObject letterMemoryCard = Instantiate(
                letterMemoryCardPrefab,
                memoryCardParent.transform
            ) as GameObject;

            int numberOfChildren = memoryCardParent.transform.childCount;
            System.Random random = new System.Random();
            int randomNumber = random.Next(0, numberOfChildren);
            letterMemoryCard.transform.SetSiblingIndex(randomNumber);

            Debug.Log(sign.letter + " letter: " + (randomNumber) + " (" + numberOfChildren + ")");

            letterMemoryCard.name = sign.letter + " letter";

            optionsGameObjects.Add(letterMemoryCard);

            // render sign card
            signMemoryCardPrefab.GetComponent<MemoryCardBehavior>().sign = sign;
            GameObject signMemoryCard = Instantiate(
                signMemoryCardPrefab,
                memoryCardParent.transform
            ) as GameObject;

            int numberOfChildrenSign = memoryCardParent.transform.childCount;
            System.Random signRandom = new System.Random();
            int signRandomNumber = random.Next(0, numberOfChildrenSign);
            signMemoryCard.transform.SetSiblingIndex(signRandomNumber);

            signMemoryCard.name = sign.letter + " sign";
            Debug.Log(sign.letter + " sign: " + (signRandomNumber) + " (" + numberOfChildrenSign + ")");

            optionsGameObjects.Add(signMemoryCard);
        });
    }

    public void coverAllUncompletedLetters(){
        optionsGameObjects.ForEach(optionGameObject => {
            optionGameObject.GetComponent<MemoryCardBehavior>().showBack();
        });
    }

    IEnumerator coverAll(){
        yield return new WaitForSeconds(1f);
        coverAllUncompletedLetters();
        coroutineFlag = true;
    }

    public IList<T> Shuffle<T>(IList<T> list)
    {
        System.Random rng = new System.Random();

        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }

        return list;
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

    public int selectNumberOfOptions()
    {
        return 6;
    }

    public Sign selectOption(ref List<Sign> options)
    {
        List<Sign> optionsTemporal = options.ToList();
        System.Random random = new System.Random();
        int randomNumber = random.Next(0, optionsTemporal.Count);

        Sign sign = RemoveAndGet(optionsTemporal, randomNumber);

        options.Remove(sign);

        return sign;
    }

    public List<Sign> selectOptions(ref List<Sign> options, int numberOfOptions)
    {
        List<Sign> selectedOptions = new List<Sign>();

        //assuring the numberOfOptions isn't greater than the options List
        numberOfOptions = (options.Count < numberOfOptions) ? options.Count : numberOfOptions;

        for (int i = 0; i < numberOfOptions; i++)
        {
            System.Random random = new System.Random();
            int randomNumber = random.Next(0, options.Count);

            selectedOptions.Add(RemoveAndGet(options, randomNumber));
        }

        return selectedOptions;
    }

    public void onGameLost(){
        memoryLevelBehaviour.onLevelLost();
    }

    public void onGameWon(){
        memoryLevelBehaviour.onLevelWon();
    }

    public void onCorrectAnswer(){
        memoryLevelBehaviour.onCorrectAnswer();
    }

    public void onIncorrectAnswer(){
        memoryLevelBehaviour.onIncorrectAnswer();
    }
}
