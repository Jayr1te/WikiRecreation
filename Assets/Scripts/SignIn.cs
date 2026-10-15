using TMPro;
using UnityEngine;

public class SignIn : MonoBehaviour
{

    public GameObject UsernameInput; // Username Input Box
    public GameObject PasswordInput; // Password Input Box
    public GameObject ErrorText; // Error Text
    public GameObject PageBase;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    bool checkSignIn()
    {

        ErrorText.GetComponent<TMP_Text>().text = "";

        var usernameText = UsernameInput.GetComponent<TMP_InputField>().text;
        if (!GlobalVars.usernames.Contains(usernameText))
        {
            ErrorText.GetComponent<TMP_Text>().text = "The Username or Password is incorrect";
            return false;
        }

        var usernameIndex = GlobalVars.usernames.IndexOf(usernameText);
        var passwordText = PasswordInput.GetComponent<TMP_InputField>().text;
        if (GlobalVars.passwords[usernameIndex] != passwordText)
        {
            ErrorText.GetComponent<TMP_Text>().text = "The Username or Password is incorrect";
            return false;
        }

        return true;
    }

    public void signIn()
    {
        if (checkSignIn())
        {
            var usernameText = UsernameInput.GetComponent<TMP_InputField>().text;
            var usernameIndex = GlobalVars.usernames.IndexOf(usernameText);
            GlobalVars.signedIn = true;
            GlobalVars.accountUsername = usernameText;
            GlobalVars.accountColor = GlobalVars.colors[usernameIndex];
            PageBase.GetComponent<PageBase>().ChangeScene("AccountPage");
        }
    }
}
