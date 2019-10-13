using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{
    [SerializeField] Transform coin; 
    // Start is called before the first frame update
    void Start()
    {
        Vector3 initialScale = coin.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        coin.localScale = new Vector3();
    }
}
