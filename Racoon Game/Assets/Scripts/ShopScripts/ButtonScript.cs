using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public string name = "";
    public int cost = 0;

    public ItemName item; 

    public GameObject twin;
    public void activate()
    {
        if(SaveLoad.currentData.dollars >= cost && ShopScript.itemsPurchased.Count < 3)
        {
            SaveLoad.currentData.dollars -= cost;
            ShopScript.dollars.text = "$" + SaveLoad.currentData.dollars;
            for(int i = 0; i < SaveLoad.currentData.itemsForSale.Count; i++)
            {
                if (SaveLoad.currentData.itemsForSale[i].name == name)
                {
                    SaveLoad.currentData.itemsForSale.RemoveAt(i);
                }
                
            }
            ShopScript.itemsPurchased.Add(this.item);
            Destroy(twin);
            Destroy(this.gameObject);
        }    
    }
}
