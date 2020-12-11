using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Newspaper : PurchasedItem
{
    private GameObject boxPrefab;
    private GameObject player;
    private GameObject newBox;
    private bool exists;
    public override void use() 
    {
        if(!exists)
        {
            newBox = Instantiate(boxPrefab, transform.position, transform.rotation);
            newBox.transform.parent = player.transform;
            newBox.transform.position = player.transform.position + new Vector3(0, 1.2f, 0);
            newBox.transform.rotation = Quaternion.Euler(85, player.transform.rotation.eulerAngles.y, player.transform.rotation.eulerAngles.z);
            exists = true;
            player.gameObject.GetComponent<racoonMovement>().box = true;
        }
        else
        {
            Destroy(newBox.gameObject);
            exists = false;
            player.gameObject.GetComponent<racoonMovement>().box = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        boxPrefab = GameObject.FindWithTag("PrefabAccessor").GetComponent<PurchasedItemPrefabAccessor>().box;
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
