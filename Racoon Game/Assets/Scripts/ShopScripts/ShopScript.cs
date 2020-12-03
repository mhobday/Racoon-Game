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

    
    
    // Start is called before the first frame update
    void Start()
    {
        dollars = GameObject.Find("Dollars").GetComponent<Text>();
        SaveLoad.Load();
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
            

            item.GetComponent<Text>().text = itemsForSale[i].name;
            item.GetComponent<ButtonScript>().name = itemsForSale[i].name;
            item.GetComponent<ButtonScript>().cost = itemsForSale[i].cost;
            item.GetComponent<ButtonScript>().item = itemsForSale[i].item;

            GameObject cost = (GameObject) Instantiate(shopItem);
            cost.transform.SetParent(shop.transform);

            cost.GetComponent<Text>().text = "$" + itemsForSale[i].cost;

            cost.GetComponent<ButtonScript>().name = itemsForSale[i].name;
            cost.GetComponent<ButtonScript>().cost = itemsForSale[i].cost;
            cost.GetComponent<ButtonScript>().item = itemsForSale[i].item;

            item.GetComponent<ButtonScript>().twin = cost;
            cost.GetComponent<ButtonScript>().twin = item;
            
        }
        
    }
}


    

