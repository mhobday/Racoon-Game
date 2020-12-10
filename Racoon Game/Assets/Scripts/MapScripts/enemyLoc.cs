using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyLoc : MonoBehaviour
{
    private void OnCollision(Collision other) {
        Debug.Log("CollisionEnter");
        if (other.gameObject.tag == "Enemy") {
            other.gameObject.GetComponent<Animator>().SetTrigger("AtStart");
        }
    }

    private void OnCollisionExit(Collision other) {
        if (other.gameObject.tag == "Enemy") {
            other.gameObject.GetComponent<Animator>().ResetTrigger("AtStart");
        }   
    }
}
