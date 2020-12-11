using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]
public class shopItem
{

    public string name;

    public int cost;
    public ItemName item;

    public shopItem (string name, int cost, ItemName item)
    {
        this.name = name;
        this.cost = cost;
        this.item = item;
    }
}
[Serializable]
public class DataPersistance
{

    public int dollars;

    public int totalDollars;

    public List<shopItem> itemsForSale = new List<shopItem>();

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

    public void SetData()
    {
        itemsForSale = new List<shopItem>();
        itemsForSale.Add(new shopItem("Distraction Garbage", 10, ItemName.Garbage));
        itemsForSale.Add(new shopItem("Box Disguise", 20, ItemName.BoxDisguise));
        itemsForSale.Add(new shopItem("Decoy Raccoon", 50, ItemName.Decoy));
        itemsForSale.Add(new shopItem("Dog Treat", 20, ItemName.Treat));
        itemsForSale.Add(new shopItem("Garage Door Clicker", 30, ItemName.Clicker));
        itemsForSale.Add(new shopItem("House Keys", 30, ItemName.Keys));
        itemsForSale.Add(new shopItem("Brick", 20, ItemName.Brick));
        itemsForSale.Add(new shopItem("Sleep Dart", 100, ItemName.SleepDart));
        itemsForSale.Add(new shopItem("Human Costume", 100, ItemName.Costume));
        itemsForSale.Add(new shopItem("Hang Glider", 200, ItemName.HangGlider));
        itemsForSale.Add(new shopItem("Spit Wads", 20, ItemName.SpitWads));

    }

    public void clearData()
    {
        itemsForSale = new List<shopItem>();
        dollars = 0;
        totalDollars = 0;
    }
}
