﻿using System.Collections;
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
        Destroy(gameObject.GetComponent<racoonMovement>().heldItem);
        gameObject.GetComponent<racoonMovement>().holdingItem = false;
    }
}