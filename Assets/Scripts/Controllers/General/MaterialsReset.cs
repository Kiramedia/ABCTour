using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialsReset : MonoBehaviour
{
    public Material[] boyMaterials;
    public Material[] girlMaterials;

    public Texture boyTexture;
    public Texture girlTexture;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Material boyMaterial in boyMaterials)
        {
            boyMaterial.SetTexture("_MainText", boyTexture);
        }

        foreach (Material girlMaterial in girlMaterials)
        {
            girlMaterial.SetTexture("_MainText", girlTexture);
        }
    }

    
}
