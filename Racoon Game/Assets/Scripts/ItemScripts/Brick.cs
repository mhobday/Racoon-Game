using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Integrate with methods in Window Script
public class Brick : PurchasedItem
{
    private GameObject brickPrefab;
    private GameObject playerHead;

    // Start is called before the first frame update
    void Start()
    {
        brickPrefab = GameObject.FindWithTag("PrefabAccessor").GetComponent<PurchasedItemPrefabAccessor>().brick;
        playerHead = GameObject.FindWithTag("PlayerHead");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionStay(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Window") {
            collisionInfo.gameObject.GetComponent<WindowScript>().breakWindow();
        }
    }

    public override void use() {
        GameObject newBrick = Instantiate(brickPrefab, playerHead.transform.position, playerHead.transform.rotation);
        newBrick.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 1000);
    }
}
