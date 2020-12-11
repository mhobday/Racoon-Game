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
            SaveLoad.currentData.totalDollars += gameObject.GetComponent<racoonMovement>().heldItem.GetComponent<grabbableItem>().cost;
            Destroy(gameObject.GetComponent<racoonMovement>().heldItem);
            gameObject.GetComponent<racoonMovement>().holdingItem = false;
        }
        else
        {
            //SaveLoad.currentData.dollars += 10;
            //SaveLoad.currentData.totalDollars += 10;
        }
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MouseLock>().Unlock();
        MenuLoader.GoToMenu(MenuName.Shop);
    }
}
