using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButtonScript : MonoBehaviour
{
    // Start is called before the first frame update

    public void HandleShopButtonOnClickEvent()
    {
        MenuLoader.GoToMenu(MenuName.Shop);
    }
}
