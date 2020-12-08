using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellItem : MonoBehaviour
{
    public bool leavingHouse = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(leavingHouse)
        {
            Sell();
        }
    }

    private void Sell()
    {
        if(gameObject.GetComponent<racoonMovement>().heldItem.GetComponent<grabbableItem>() != null)
        {
            SaveLoad.currentData.dollars += gameObject.GetComponent<racoonMovement>().heldItem.GetComponent<grabbableItem>().cost;
            SaveLoad.currentData.totalDollars += gameObject.GetComponent<racoonMovement>().heldItem.GetComponent<grabbableItem>().cost;
        }
        else
        {
            SaveLoad.currentData.dollars += 10;
            SaveLoad.currentData.totalDollars += 10;
        }
        Destroy(gameObject.GetComponent<racoonMovement>().heldItem);
        gameObject.GetComponent<racoonMovement>().holdingItem = false;
        MenuLoader.GoToMenu(MenuName.Main);
    }
}
