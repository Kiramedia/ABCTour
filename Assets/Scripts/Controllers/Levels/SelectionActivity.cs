using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionActivity : MonoBehaviour
{
    public List<Vector2> possiblePositions;
    public int numberOfItems;
    public List<ActivityItem> correctItems;
    public List<ActivityItem> incorrectItems;
    public int numOfCorrect = 0;
    public GameObject[] turns;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        InitObjectPositions();
        if(turns.Length == 2){
            turns[0].SetActive(true);
            turns[1].SetActive(false);
        }
    }

    void InitObjectPositions(){
        List<ActivityItem> correctTemporal = new List<ActivityItem>(correctItems);
        List<ActivityItem> incorrectTemporal =  new List<ActivityItem>(incorrectItems);
        List<Vector2> temporalPositions =  new List<Vector2>(possiblePositions);

        for (int i = 0; i < numberOfItems; i++)
        {
            int indexPosition = Random.Range(0, temporalPositions.Count);
            if(correctTemporal.Count != 0){
                correctTemporal[0].gameObject.SetActive(true);
                correctTemporal[0].gameObject.transform.position = new Vector3(temporalPositions[indexPosition].x, temporalPositions[indexPosition].y, 0);
                correctTemporal.RemoveAt(0);
            }else if(incorrectTemporal.Count != 0){
                int indexIncorrect = Random.Range(0, incorrectTemporal.Count);
                incorrectTemporal[indexIncorrect].gameObject.SetActive(true);
                incorrectTemporal[indexIncorrect].gameObject.transform.position = new Vector3(temporalPositions[indexPosition].x, temporalPositions[indexPosition].y, 0);
                incorrectTemporal.RemoveAt(indexIncorrect);
            }else{
                break;
            }

            temporalPositions.RemoveAt(indexPosition);
        }
    }

    public void CheckIfFinish(){
        numOfCorrect++;
        if(numOfCorrect >= correctItems.Count){
            if(turns.Length == 2){
                turns[0].SetActive(false);
                turns[1].SetActive(false);
            }
            Debug.Log("Todo Nice");
        }else{
            ChangeTurn();
        }
    }

    public void ChangeTurn(){
        if(turns.Length == 2 && turns[0].activeSelf){
            turns[0].SetActive(false);
            turns[1].SetActive(true);
        }else if(turns.Length == 2){
            turns[0].SetActive(true);
            turns[1].SetActive(false);
        }
    }
}
