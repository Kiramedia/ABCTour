using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SelectOptionsBehaviour : MonoBehaviour
{
    public TestModalController testModalController;
    public Abecedary levelSigns;
    public Abecedary abecedary;

    [NonSerialized]
    public Sign correctOption;
    [NonSerialized]
    public List<Sign> incorrectOptions = new List<Sign>();

    public void setup()
    {
        selectOptions();
    }

    public void selectOptions()
    {
        int numberOfOptions = selectNumberOfOptions();

        if (numberOfOptions < 1) return;

        List<Sign> temporalLevelSigns = levelSigns.signs.ToList();
        List<Sign> temporalAbecedary = abecedary.signs.ToList();

        correctOption = selectOption(ref temporalLevelSigns);

        incorrectOptions = new List<Sign>();

        int numberOfSimilarIncorrectOptions = testModalController.numberOfSimilarOptions < numberOfOptions ? testModalController.numberOfSimilarOptions : numberOfOptions;
        incorrectOptions.AddRange(selectOptions(ref temporalLevelSigns, numberOfSimilarIncorrectOptions));

        //List to remove from abecedary
        List<Sign> listToRemove = new List<Sign>(incorrectOptions);
        listToRemove.Add(correctOption);

        temporalAbecedary = temporalAbecedary.Except(listToRemove).ToList();

        int numberOfIncorrectOptions = numberOfOptions - (incorrectOptions.Count + 1);

        incorrectOptions.AddRange(selectOptions(ref temporalAbecedary, numberOfIncorrectOptions));

        abecedary.signs.ToList().ForEach(sign => {Debug.Log("abc " + sign.letter);});
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
        int numberOfOptions = 0;
        if (testModalController.level == 1)
            numberOfOptions = 3;
        else if (testModalController.level == 2)
            numberOfOptions = 6;
        else if (testModalController.level == 3)
            numberOfOptions = 12;

        return numberOfOptions;
    }

    public Sign selectOption(ref List<Sign> options)
    {
        System.Random random = new System.Random();
        int randomNumber = random.Next(0, options.Count);
        return RemoveAndGet(options, randomNumber);
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
}
