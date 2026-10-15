using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AccountPage : MonoBehaviour
{

    public GameObject UsernameText;
    public GameObject EmailText;
    public GameObject RedSlider;
    public GameObject GreenSlider;
    public GameObject BlueSlider;
    public GameObject AccountIcon;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RedSlider.GetComponent<Slider>().value = GlobalVars.accountColor.r;
        GreenSlider.GetComponent<Slider>().value = GlobalVars.accountColor.g;
        BlueSlider.GetComponent<Slider>().value = GlobalVars.accountColor.b;
        AccountIcon.GetComponent<Image>().color = GlobalVars.accountColor;
    }

    // Update is called once per frame
    void Update()
    {
        var red = RedSlider.GetComponent<Slider>().value;
        var green = GreenSlider.GetComponent<Slider>().value;
        var blue = BlueSlider.GetComponent<Slider>().value;
        AccountIcon.GetComponent<Image>().color = new Color(red,green,blue);

        UsernameText.GetComponent<TMP_Text>().text = GlobalVars.accountUsername;
        var usernameText = GlobalVars.accountUsername;
        var usernameIndex = GlobalVars.usernames.IndexOf(usernameText);
        EmailText.GetComponent<TMP_Text>().text = GlobalVars.emails[usernameIndex];
    }

    public void ApplyColor()
    {
        var red = RedSlider.GetComponent<Slider>().value;
        var green = GreenSlider.GetComponent<Slider>().value;
        var blue = BlueSlider.GetComponent<Slider>().value;
        GlobalVars.accountColor = new Color(red,green,blue);
        
        var usernameText = GlobalVars.accountUsername;
        var usernameIndex = GlobalVars.usernames.IndexOf(usernameText);
        GlobalVars.colors[usernameIndex] = new Color(red,green,blue);
    }
}
