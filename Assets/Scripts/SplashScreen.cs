using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
    // Start is called before the first frame update

    public Image splashimage;
    public string loadlevel;

    IEnumerator Start()
    {
        splashimage.canvasRenderer.SetAlpha(0.0f);
        FadeIn();
        yield return new WaitForSeconds(2.5f);
        FadeOut();
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(loadlevel);
    }

    // Update is called once per frame
    void FadeIn()
    {
        splashimage.CrossFadeAlpha(1.0f, 1.5f, false);
    }

    void FadeOut()
    {
        splashimage.CrossFadeAlpha(0.0f, 2.5f, false);
    }
}
