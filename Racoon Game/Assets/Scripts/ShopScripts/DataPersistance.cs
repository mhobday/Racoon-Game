using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]
public class shopItem
{
    
    public string name;

    public int cost;

    public shopItem (string name, int cost)
    {
        this.name = name;
        this.cost = cost;
    }
}
[Serializable]
public class DataPersistance 
{
    
    public int dollars;

    public List<shopItem> itemsForSale = new List<shopItem>();

    public List<String> itemsAcquired = new List<String>();


    public void removeMember(String name)
    {
        for(int i = 0; i < itemsForSale.Count; i++)
        {
            if(itemsForSale[i].name.Equals(name))
            {
                itemsForSale.RemoveAt(i);
            }
        }
    }

    public void clearMembers()
    {
        itemsForSale = new List<shopItem>();
    }

    public void SetTest()
    {
        itemsForSale.Add(new shopItem("a", 1));
        itemsForSale.Add(new shopItem("b", 2));
        itemsForSale.Add(new shopItem("c", 3));

    }
}
