using UnityEngine.UI;
using UnityEngine;

public class BackPackItem : MonoBehaviour
{
    public Image imageContainer;
    public Sprite misstakeItem;

    public void SetMisstakeIcon(){
        imageContainer.sprite = misstakeItem;
    }
}
