using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < ShopScript.itemsPurchased.Count; i++)
        {
            this.gameObject.AddComponent(System.Type.GetType(ShopScript.itemsPurchased[i].ToString()));
        }
    }
}
