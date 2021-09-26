using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class OrganizeOptions : MonoBehaviour
{
    public int maxColumnsNumber;
    public Action action;
    private GameObject[] options;

    // Start is called before the first frame update
    void Start()
    {
        organizeOptions();
    }

    public void setOptions(GameObject[] options){
        this.options = options;
        organizeOptions();
    }

    public void organizeOptions(){
        
    }
}
