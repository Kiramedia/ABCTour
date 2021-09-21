using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackpackController : MonoBehaviour
{
    private int numOfItems;
    public List<int> currentTrophys;
    public Material grayMaterial;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        numOfItems = transform.childCount;
        SetCurrentTrophys();
    }

    public void SetCurrentTrophys(){
        for (int i = 0; i < numOfItems; i++)
        {
            if(currentTrophys.Contains(i)){
                GameObject child = transform.GetChild(i).gameObject;
                child.GetComponent<Image>().material = null;
                child.transform.GetChild(0).GetComponent<Image>().material = null;
                child.transform.GetChild(1).GetComponent<Image>().enabled = false;
                child.transform.GetChild(2).GetComponent<Image>().enabled = true;
            }else{
                GameObject child = transform.GetChild(i).gameObject;
                child.GetComponent<Image>().material = grayMaterial;
                child.transform.GetChild(0).GetComponent<Image>().material = grayMaterial;
                child.transform.GetChild(1).GetComponent<Image>().enabled = true;
                child.transform.GetChild(2).GetComponent<Image>().enabled = false;
            }
        }
    }
}
