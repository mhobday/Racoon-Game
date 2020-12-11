using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepDartBehavior : MonoBehaviour
{
    // void Update() {
    //     Debug.Log("Updating SleepDartBehavior");
    // }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.GetType().Name);
        if (other.gameObject.tag == "Enemy" && other.GetType().Name == "CapsuleCollider" && other.gameObject.GetComponent<EnemyMovement>() != null) {
            other.gameObject.GetComponent<EnemyMovement>().Sleep();
        }
    }
}
