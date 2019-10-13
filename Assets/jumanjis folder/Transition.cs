using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{

    //Juma's Spaghetti 
    public float speed = 1f;
    public Color color1;
    public Color color2;
    public Color color3;
    public Color color4;
    public Color color5;
    public Color color6;
    public Color color7;
    public Color currentColor;
    MeshRenderer myRenderer;
    int colorIndex;
    float startTime;

    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<MeshRenderer>();
        myRenderer.material.color = color1;
        currentColor = color1;
        colorIndex = 1;
    }

    // Update is called once per frame
    void Update()
    {

        myRenderer.material.color = Color.Lerp(myRenderer.material.color, currentColor, 0.01f);

        if (Input.GetKeyDown(KeyCode.Return))
        {
            colorIndex += 1;
        }

        if (colorIndex == 1)
        {
            currentColor = color1;
        }

        if (colorIndex == 2)
        {
            currentColor = color2;
        }

        if (colorIndex == 3)
        {
            currentColor = color3;
        }

        if (colorIndex == 4)
        {

            currentColor = color4;
        }

        if (colorIndex == 5)
        {

            currentColor = color5;
        }

        if (colorIndex == 6)
        {

            currentColor = color6;
        }

        if (colorIndex >= 7)
        {
            colorIndex = 1;
        }
    }
}
