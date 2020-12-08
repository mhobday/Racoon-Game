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
        if(gameObject.GetComponent<racoonMovement>().holdingItem)
        {
            SaveLoad.currentData.dollars += gameObject.GetComponent<racoonMovement>().heldItem.GetComponent<grabbableItem>().cost;
            Destroy(gameObject.GetComponent<racoonMovement>().heldItem);
            gameObject.GetComponent<racoonMovement>().holdingItem = false;
        }
        else
        {
            //SaveLoad.currentData.dollars += 10;
        }
        MenuLoader.GoToMenu(MenuName.Main);
    }
}
