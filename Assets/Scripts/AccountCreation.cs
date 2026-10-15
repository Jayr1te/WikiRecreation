using System;
using System.Linq;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System.Runtime.Serialization;

public class AccountCreation : MonoBehaviour
{

    public GameObject UsernameInput; // Username Input Box
    public GameObject EmailInput; // Email Input Box
    public GameObject PasswordInput; // Password Input Box
    public GameObject PasswordConfirmInput; // Password Confirmation Input Box
    public GameObject UsernameError; // Username Error Text
    public GameObject EmailError; // Email Error Text
    public GameObject PasswordError; // Password Error Text
    public GameObject PasswordConfirmError; // Password Confirmation Error Text
    public GameObject PageBase;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        checkUsername();
        checkEmail();
        checkPassword();
        checkConfirmPassword();
    }

    bool checkUsername()
    {
        var usernameText = UsernameInput.GetComponent<TMP_InputField>().text;
        UsernameError.GetComponent<TMP_Text>().text = "";

        if (usernameText.Length == 0)
        {
            UsernameError.GetComponent<TMP_Text>().text = "This username is invalid";
            return false;
        }

        foreach (String name in GlobalVars.usernames)
        {

            if (usernameText == name)
            {
                UsernameError.GetComponent<TMP_Text>().text = "This username is already used by another account";
                return false;
            }
        }
        return true;
    }

    bool checkEmail()
    {
        var emailText = EmailInput.GetComponent<TMP_InputField>().text;
        EmailError.GetComponent<TMP_Text>().text = "";

        if (!emailText.EndsWith("@gmail.com") && !emailText.EndsWith("@outlook.com") && !emailText.EndsWith("@hotmail.com") && !emailText.EndsWith("@yahoo.com") && !emailText.EndsWith("@kent.edu"))
        {
            EmailError.GetComponent<TMP_Text>().text = "This email is invalid";
            return false;
        }

        foreach (String email in GlobalVars.emails)
        {
            if (emailText == email)
            {
                EmailError.GetComponent<TMP_Text>().text = "This email is already used by another account";
                return false;
            }
        }
        return true;
    }

    bool checkPassword()
    {
        var passwordText = PasswordInput.GetComponent<TMP_InputField>().text;
        var passwordConfirmText = PasswordConfirmInput.GetComponent<TMP_InputField>().text;
        PasswordError.GetComponent<TMP_Text>().text = "";

        if (passwordText.Length < 8)
        {
            PasswordError.GetComponent<TMP_Text>().text = "Password needs to be at least 8 characters";
            return false;
        }

        if (passwordText.Contains(" "))
        {
            PasswordError.GetComponent<TMP_Text>().text = "Password cannot contain spaces";
            return false;
        }

        if (!passwordText.Any(char.IsDigit))
        {
            PasswordError.GetComponent<TMP_Text>().text = "Password needs to contain at least 1 number";
            return false;
        }

        if (!Regex.IsMatch(passwordText, "[^a-zA-Z0-9]"))
        {
            PasswordError.GetComponent<TMP_Text>().text = "Password needs to contain at least 1 special character";
            return false;
        }

        return true;
    }

    bool checkConfirmPassword()
    {
        var passwordText = PasswordInput.GetComponent<TMP_InputField>().text;
        var passwordConfirmText = PasswordConfirmInput.GetComponent<TMP_InputField>().text;
        PasswordConfirmError.GetComponent<TMP_Text>().text = "";

        if (passwordText != passwordConfirmText)
        {
            PasswordConfirmError.GetComponent<TMP_Text>().text = "Passwords do not match";
            return false;
        }

        return true;
    }

    public void CreateAccount()
    {
        var usernameText = UsernameInput.GetComponent<TMP_InputField>().text;
        var emailText = EmailInput.GetComponent<TMP_InputField>().text;
        var passwordText = PasswordInput.GetComponent<TMP_InputField>().text;
        var passwordConfirmText = PasswordConfirmInput.GetComponent<TMP_InputField>().text;
        var success = true;

        if (!checkUsername())
        {
            success = false;
        }

        if (!checkEmail())
        {
            success = false;
        }

        if (!checkPassword())
        {
            success = false;
        }

        if (!checkConfirmPassword())
        {
            success = false;
        }

        if (success)
        {
            GlobalVars.usernames.Add(usernameText);
            GlobalVars.emails.Add(emailText);
            GlobalVars.passwords.Add(passwordText);
            GlobalVars.signedIn = true;
            GlobalVars.accountUsername = usernameText;
            PageBase.GetComponent<PageBase>().ChangeScene("AccountPage");
        }
    }
}
