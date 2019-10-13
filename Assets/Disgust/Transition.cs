using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    //Juma's Spaghetti 
    public Material[] material;
    Renderer rend;
    int colorIndex;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
        colorIndex = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            colorIndex += 1;
        }

        if (colorIndex == 1)
        {
            rend.sharedMaterial = material[0];
        }

        if (colorIndex == 2)
        {
            rend.sharedMaterial = material[1];
        }

        if (colorIndex == 3)
        {
            rend.sharedMaterial = material[2];
        }

        if (colorIndex >= 4)
        {
            colorIndex = 1;
        }
    }
}
