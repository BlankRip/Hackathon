using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Click : MonoBehaviour
{
    [Header("Things for coin click")]
    // Things required for the coin click
    [SerializeField] Transform coin;
    public TextMeshProUGUI cashText;
    [HideInInspector] public float cash = 0;
    Vector3 initialScale;

    [Header("Things for game pannel displays")]
    // Things required for the pannel display
    [SerializeField] GameObject infoPannel;
    [SerializeField] GameObject investPannel;
    [SerializeField] GameObject botTip;

    bool showInfo = false;
    bool showInvest = false;
    bool showTip = false;

    [Header("Things for animation")]
    //Things required for the animations of the bot
    [SerializeField] Animator botAnimate;

    [Header("Things for card lost interaction")]
    //Things needed for the card interaction
    [SerializeField] GameObject isCardLost;
    [SerializeField] GameObject doYouLockIt;
    [SerializeField] GameObject cardLocked;
    [SerializeField] GameObject lockTip;

    [Header("For sounds")]
    // To have sound effects
    [SerializeField] AudioSource aSource;
    [SerializeField] AudioClip coinClickClip;
    [SerializeField] AudioClip investClip;

    void Start()
    {
        initialScale = coin.localScale;
        cashText.text = cash.ToString();
    }

    // The function to be done when on clicking the coin
    public void OnClickCoin()
    {
        aSource.PlayOneShot(coinClickClip);
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



    // Card lock interation UI
    // Show is card lock text
    public void IsCardLost()
    {
        isCardLost.SetActive(true);
    }
    
    //if user did not loose his card
    public void CardNotLost()
    {
        isCardLost.SetActive(false);
    }

    // If user lost his card ask if he want to lock
    public void DoYouWantLock()
    {
        doYouLockIt.SetActive(true);
        isCardLost.SetActive(false);
    }

    // Show that card is now locked
    public void CardLocked()
    {
        cardLocked.SetActive(true);
        doYouLockIt.SetActive(false);
    }

    // Tip that he should lock
    public void YouShouldLock()
    {
        lockTip.SetActive(true);
        doYouLockIt.SetActive(false);
    }

    // Back to game from card locked message
    public void BackToGameCL()
    {
        cardLocked.SetActive(false);
    }

    //Back to game from tip message
    public void BackToGameTip()
    {
        lockTip.SetActive(false);
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
        yield return new WaitForSeconds(1f);
        botTip.SetActive(true);
        showTip = true;
    }
}
