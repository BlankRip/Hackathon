using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UserDetails : MonoBehaviour
{
    // Start is called before the first frame update

    public TMP_InputField personname;
    public TMP_InputField age;
    public TMP_InputField username;
    public TMP_InputField password;
    public TMP_InputField job;
    public TMP_InputField ccn;

    public Button button;

    private int index = 0;

    private string _name;
    private string _age;
    private string _uname;
    private string _pword;
    private string _job;
    private string _ccn;
    Transition colorswith;

    void Start()
    {
        personname.gameObject.SetActive(true);
        age.gameObject.SetActive(false);
        username.gameObject.SetActive(false);
        password.gameObject.SetActive(false);
        job.gameObject.SetActive(false);
        ccn.gameObject.SetActive(false);
        colorswith = FindObjectOfType<Transition>();
    }

    // Update is called once per frame
    public void nxt()
    {
        colorswith.ChngeColor();

        if (index == 0)
        {
            _name = personname.textComponent.ToString();
            age.gameObject.SetActive(true);
            personname.gameObject.SetActive(false);
        }
        else if (index == 1)
        {
            _age = age.textComponent.ToString();
            username.gameObject.SetActive(true);
            age.gameObject.SetActive(false);
        }
        else if (index == 2)
        {
            _uname = username.textComponent.ToString();
            password.gameObject.SetActive(true);
            username.gameObject.SetActive(false);
        }
        else if(index == 3)
        {
            _pword = password.textComponent.ToString();
            job.gameObject.SetActive(true);
            password.gameObject.SetActive(false);
        }
        else if(index == 4)
        {
            _job = job.textComponent.ToString();
            ccn.gameObject.SetActive(true);
            job.gameObject.SetActive(false);

        }
        else if(index == 5)
        {
            _ccn = ccn.textComponent.ToString();
            ccn.gameObject.SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        index++;
    }
}
