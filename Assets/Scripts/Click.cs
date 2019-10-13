using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Click : MonoBehaviour
{
    [SerializeField] Transform coin;
    Vector3 initialScale;
    [SerializeField] TextMeshProUGUI cashText;
    [HideInInspector] public int cash = 0;
    
    void Start()
    {
        initialScale = coin.localScale;
        cashText.text = cash.ToString();
    }


    public void OnClick()
    {
        coin.localScale = initialScale + new Vector3(0.02f, 0.02f, 0.02f);
        StartCoroutine(ResetSize());
        cash++;
        cashText.text = cash.ToString();
    }

    IEnumerator ResetSize()
    {
        yield return new WaitForSeconds(0.1f);
        coin.localScale = initialScale;
    }
}
