using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class to control the backpack behaviour
/// </summary>
public class BackpackController : MonoBehaviour
{

    /// <summary>
    /// Number of items in the backpack, defines the maxSize of the currentTrophies
    /// </summary>
    private int numOfItems;

    /// <summary>
    /// List with index that identifies the trophies won
    /// </summary>
    public List<int> currentTrophies;

    /// <summary>
    /// List with trophies won level 3-4 when misstakes
    /// </summary>
    public List<int> misstakeTrophies;

    /// <summary>
    /// Material for disabled porpouses
    /// </summary>
    public Material grayMaterial;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        numOfItems = transform.childCount;
        SetCurrentTrophies();
    }

    /// <summary>
    /// Method to init current trophies
    /// Set disable and enable trophies in the backpack
    /// </summary>
    public void SetCurrentTrophies()
    {
        for (int i = 0; i < numOfItems; i++)
        {
            if (currentTrophies.Contains(i))
            {
                GameObject child = transform.GetChild(i).gameObject;
                child.GetComponent<Image>().material = null;
                child.transform.GetChild(0).GetComponent<Image>().material = null;
                child.transform.GetChild(1).GetComponent<Image>().enabled = false;
                child.transform.GetChild(2).GetComponent<Image>().enabled = true;

                if(misstakeTrophies.Contains(i)){
                    child.GetComponent<BackPackItem>().SetMisstakeIcon();
                }
            }
            else
            {
                GameObject child = transform.GetChild(i).gameObject;
                child.GetComponent<Image>().material = grayMaterial;
                child.transform.GetChild(0).GetComponent<Image>().material = grayMaterial;
                child.transform.GetChild(1).GetComponent<Image>().enabled = true;
                child.transform.GetChild(2).GetComponent<Image>().enabled = false;
            }
        }
    }
}
