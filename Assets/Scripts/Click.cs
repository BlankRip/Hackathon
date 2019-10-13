using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Click : MonoBehaviour
{
    // Things required for the coin click
    [SerializeField] Transform coin;
    [SerializeField] TextMeshProUGUI cashText;
    [HideInInspector] public int cash = 0;
    Vector3 initialScale;

    // Things required for the pannel display
    [SerializeField] GameObject infoPannel;
    [SerializeField] GameObject investPannel;
    [SerializeField] GameObject botTip;

    bool showInfo = false;
    bool showInvest = false;
    bool showTip = false;

    //Things required for the animations of the bot
    [SerializeField] Animator botAnimate;
    
    void Start()
    {
        initialScale = coin.localScale;
        cashText.text = cash.ToString();
    }

    // The function to be done when on clicking the coin
    public void OnClickCoin()
    {
        coin.localScale = initialScale + new Vector3(0.02f, 0.02f, 0.02f);
        StartCoroutine(ResetSize());
        cash++;
        cashText.text = cash.ToString();
    }

    // The function that displayes the info pannel if its not showing, and closes all other pannels if any showing
    public void OnClickInformation()
    {
        if(!showInfo)
        {
            botAnimate.SetBool("Open_Anim", false);
            botTip.SetActive(false);
            showTip = false;
            investPannel.SetActive(false);
            showInvest = false;
            infoPannel.SetActive(true);
            showInfo = true;
        }
        else if (showInfo)
        {
            infoPannel.SetActive(false);
            showInfo = false;
        }
    }

    // The function that displayes the invest pannel if its not showing, and closes all other pannels if any showing
    public void OnClickInvest()
    {
        if (!showInvest)
        {
            botAnimate.SetBool("Open_Anim", false);
            botTip.SetActive(false);
            showTip = false;
            infoPannel.SetActive(false);
            showInfo = false;
            investPannel.SetActive(true);
            showInvest = true;
        }
        else if (showInvest)
        {
            investPannel.SetActive(false);
            showInvest = false;
        }
    }

    // The function that displayes the bot pannel if its not showing, and closes all other pannels if any showing
    public void OnClickBot()
    {
        if(!showTip)
        {
            StartCoroutine(ShowTheTipNow());
            botAnimate.SetBool("Open_Anim", true);
            infoPannel.SetActive(false);
            showInfo = false;
            investPannel.SetActive(false);
            showInvest = false;
        }
        else if(showTip)
        {
            botAnimate.SetBool("Open_Anim", false);
            botTip.SetActive(false);
            showTip = false;
        }
        
    }

    // To set the size of the coin back to the original
    IEnumerator ResetSize()
    {
        yield return new WaitForSeconds(0.1f);
        coin.localScale = initialScale;
    }

    // To make the bot pannal appear after a bit as we need to wait for the animation to complete
    IEnumerator ShowTheTipNow()
    {
        yield return new WaitForSeconds(0.6f);
        botTip.SetActive(true);
        showTip = true;
    }
}
