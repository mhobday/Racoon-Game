using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShopScript : MonoBehaviour
{
    public GameObject shopItem;

    public static Text dollars;

    public static int dollarAmount;

    static List<shopItem> itemsForSale = new List<shopItem>();

    GameObject shop;

    public static List<ItemName> itemsPurchased = new List<ItemName>();

    private static bool isLoaded = false;



    // Start is called before the first frame update
    void Start()
    {
        dollars = GameObject.Find("Dollars").GetComponent<Text>();
        if (!ShopScript.isLoaded) {
            SaveLoad.Load();
            ShopScript.isLoaded = true;
        }
        //SaveLoad.testData();
        dollars.text = "$" + SaveLoad.currentData.dollars;
        shop = GameObject.Find("Content");
        itemsForSale = SaveLoad.currentData.itemsForSale;
        PopulateShop();
    }

    public void HandleMainMenuButtonOnClickEvent()
    {
        MenuLoader.GoToMenu(MenuName.Main);
    }

    public void HandleRaccoonissanceButtonOnClickEvent()
    {
        SaveLoad.Save();
        MenuLoader.GoToMenu(MenuName.Raccoonissance);
    }

    void OnApplicationQuit()
    {
        SaveLoad.Save();
        Debug.Log("saved");
    }

    void PopulateShop()
    {
        for(int i = 0; i < itemsForSale.Count ; i++)
        {
            GameObject item = (GameObject) Instantiate(shopItem);
            item.transform.SetParent(shop.transform);


            item.transform.GetChild(0).gameObject.GetComponent<Text>().text = itemsForSale[i].name;
            item.GetComponent<ButtonScript>().name = itemsForSale[i].name;
            item.GetComponent<ButtonScript>().cost = itemsForSale[i].cost;
            item.GetComponent<ButtonScript>().item = itemsForSale[i].item;
            item.transform.GetChild(1).gameObject.GetComponent<Text>().text = "$" + itemsForSale[i].cost;
        }
        Debug.Log(itemsForSale);

    }
}




