using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InvestmentThingy : MonoBehaviour
{
    [SerializeField] int cost;
    [SerializeField] [Range(0, 1.5f)] float profitMultiplier;
    [SerializeField] [Range(0, 1.15f)] float lossMultiplier;
    [SerializeField] float waitTime;
    [SerializeField] [Range(0, 0.7f)] float waitTimeMultiplier;
    [SerializeField] TextMeshProUGUI theText;
    [SerializeField] GameObject icon;
    [SerializeField] AudioClip investedClip;
    AudioSource seSource;

    [SerializeField] bool retures;
    [SerializeField] bool profit;
    bool onHold;
    Click playerCredit;

    // Start is called before the first frame update
    void Start()
    {
        seSource = FindObjectOfType<AudioSource>();
        playerCredit = FindObjectOfType<Click>();
        theText.text = cost.ToString();
    }


    public void Purchase()
    {
        if(!onHold)
        {
            if (retures)
            {
                if (playerCredit.cash >= cost)
                {
                    seSource.PlayOneShot(investedClip);
                    playerCredit.cash -= cost;
                    playerCredit.cashText.text = playerCredit.cash.ToString();
                    theText.text = "Wait";
                    icon.SetActive(true);
                    onHold = true;
                    StartCoroutine(WaitTime());
                }
            }
            else
            {
                if (playerCredit.cash >= cost)
                {
                    seSource.PlayOneShot(investedClip);
                    playerCredit.cash -= cost;
                    playerCredit.cashText.text = playerCredit.cash.ToString();
                    theText.text = "Sold";
                    theText.color = Color.red;
                    icon.SetActive(true);
                    onHold = true;
                }
            }
        }
        
    }

    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(waitTime);
        if (profit)
        {
            playerCredit.cash += Mathf.RoundToInt(cost * profitMultiplier);
            playerCredit.cashText.text = playerCredit.cash.ToString();
            cost = cost + 80;
            waitTime += waitTime * waitTimeMultiplier;
        }
        else
        {
            playerCredit.cash -= Mathf.RoundToInt(cost * lossMultiplier);
            playerCredit.cashText.text = playerCredit.cash.ToString();
            waitTime += waitTime * waitTimeMultiplier;
        }
        theText.text = cost.ToString();
        icon.SetActive(false);
        onHold = false;
        
    }
}
