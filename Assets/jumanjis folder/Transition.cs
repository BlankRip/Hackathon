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
    int index = 0;
    float startTime;
    float time = 0;

    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<MeshRenderer>();
        myRenderer.material.color = color1;
        currentColor = color1;
        colorIndex = 1;
    }


     public void ChngeColor()
    {
        colorIndex += 1;
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        myRenderer.material.color = Color.Lerp(myRenderer.material.color, currentColor, time);


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
