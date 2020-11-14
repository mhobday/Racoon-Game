using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class MenuLoader
{
    public static void GoToMenu(MenuName name)
    {
        switch (name)
        {
            case MenuName.Main:
                SceneManager.LoadScene("TestMain");
                break;

            case MenuName.Shop:
                SceneManager.LoadScene("Gabe's scene");
                break;

            case MenuName.Raccoonissance:
                SceneManager.LoadScene("TestSteal");
                break;    
        }
    }
}
