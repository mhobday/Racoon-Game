using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBehavior : MonoBehaviour
{
    void OnCollisionStay(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Window") {
            collisionInfo.gameObject.GetComponent<WindowScript>().breakWindow();
        }
    }
}
