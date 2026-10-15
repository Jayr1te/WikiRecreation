using System;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalVars
{
    public static String currentPage = "Home"; // The scene name of the page that is currently loaded
    public static String previousPage; // The scene name of the last page previously loaded
    public static GameObject pageObject; // The PageBase prefab object in the currently loaded scene


    public static List<String> usernames = new List<String>();
    public static List<String> emails = new List<String>();
    public static List<String> passwords = new List<String>();
    public static List<Color> colors = new List<Color>();

    public static bool signedIn = false;
    public static String accountUsername = "";
    public static Color accountColor = Color.red;
}
