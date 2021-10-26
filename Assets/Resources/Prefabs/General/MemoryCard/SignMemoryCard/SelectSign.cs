using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SelectSign : MonoBehaviour
{
    public MemoryCardBehavior memoryCardBehavior;
    public Image image;
    // Start is called before the first frame update
    void Start()
    {
        image.sprite = memoryCardBehavior.sign.sign;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
