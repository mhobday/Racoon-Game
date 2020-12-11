using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Use Sleep method under EnemyMovement to cause the effects of the sleep dart.
public class SleepDart : PurchasedItem
{

    private GameObject sleepDartPrefab;
    private GameObject playerHead;

    // Start is called before the first frame update
    void Start()
    {
        sleepDartPrefab = GameObject.FindWithTag("PrefabAccessor").GetComponent<PurchasedItemPrefabAccessor>().sleepDart;
        playerHead = GameObject.FindWithTag("PlayerHead");
    }

    public override void use() {
        GameObject newSleepDart = Instantiate(sleepDartPrefab, playerHead.transform.position, playerHead.transform.rotation);
        newSleepDart.transform.Rotate(90, 0, 0);
        newSleepDart.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 1000);
    }
}
