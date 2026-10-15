using System;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PageBase : MonoBehaviour
{

    public GameObject SignInButton;
    public GameObject CreateAccountButton;
    public GameObject SignOutButton;
    public GameObject AccountButton;
    public GameObject AccountIcon;
    public GameObject UsernameText;
    public GameObject PageContent; // Everything on the page that isn't part of the background or top bar should be a child of this

    public bool shouldScroll = false; // Whether or not the page should be able to scroll
    public float scrollBottom = 0; // The lowest point the page should be allowed to scroll to
    float scroll = 0; // Current scroll value, will be applied to the page content child

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GlobalVars.previousPage = GlobalVars.currentPage; // Set the previous page
        GlobalVars.currentPage = SceneManager.GetActiveScene().name; // Update the current page
        GlobalVars.pageObject = gameObject; // Update the current page object
    }

    // Update is called once per frame
    void Update()
    {
        
        scroll = Mathf.Clamp(scroll,0,scrollBottom);
        PageContent.gameObject.transform.position = new Vector3(960,540 + scroll,0);

        if (GlobalVars.signedIn)
        {
            SignInButton.SetActive(false);
            CreateAccountButton.SetActive(false);
            SignOutButton.SetActive(true);
            AccountButton.SetActive(true);
            AccountIcon.SetActive(true);
            UsernameText.SetActive(true);
            UsernameText.GetComponent<TMP_Text>().text = GlobalVars.accountUsername;
        }
        else
        {
            SignInButton.SetActive(true);
            CreateAccountButton.SetActive(true);
            SignOutButton.SetActive(false);
            AccountButton.SetActive(false);
            AccountIcon.SetActive(false);
            UsernameText.SetActive(false);
            UsernameText.GetComponent<TMP_Text>().text = "";
        }

        // Home Page Shortcut
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.H))
        {
            ChangeScene("Home");
        }

        // Previous Page Shortcut
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Z))
        {
            ChangeScene(GlobalVars.previousPage);
        }

    }

    // Changes the Scene to scene
    public void ChangeScene(String scene)
    {
        SceneManager.LoadScene(scene);
    }

    // Sign Out of account
    public void SignOut()
    {
        GlobalVars.signedIn = false;
        GlobalVars.accountUsername = "";
        ChangeScene("Home");
    }
}
