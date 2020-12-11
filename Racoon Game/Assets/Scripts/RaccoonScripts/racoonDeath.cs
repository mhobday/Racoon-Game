using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class racoonDeath : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("test");
        if(other.gameObject.CompareTag("Enemy"))
        {
            this.gameObject.GetComponent<Animation>().Play("Death");
            this.gameObject.GetComponent<racoonMovement>().enabled = false;
        }
    }
}
