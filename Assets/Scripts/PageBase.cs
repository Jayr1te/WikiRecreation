using System;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PageBase : MonoBehaviour
{

    public GameObject SignInButton;
    public GameObject CreateAccountButton;
    public GameObject SignOutButton;
    public GameObject AccountButton;
    public GameObject AccountIcon;
    public GameObject UsernameText;
    public GameObject PageContent; // Everything on the page that isn't part of the background or top bar should be a child of this

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
        if (GlobalVars.signedIn)
        {
            SignInButton.SetActive(false);
            CreateAccountButton.SetActive(false);
            SignOutButton.SetActive(true);
            AccountButton.SetActive(true);
            AccountIcon.SetActive(true);
            AccountIcon.GetComponent<Image>().color = GlobalVars.accountColor;
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
