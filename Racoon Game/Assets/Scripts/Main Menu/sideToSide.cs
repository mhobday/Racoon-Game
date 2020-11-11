using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sideToSide : MonoBehaviour
{
    public int distance;
    private int positionTracker = 0;
    private bool right = true;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (right && positionTracker < distance) {
            this.gameObject.transform.position += Vector3.right;
            positionTracker++;
        } else if (!right && positionTracker < distance) {
            this.gameObject.transform.position += Vector3.left;
            positionTracker++;
        } else {
            right = !right;
            positionTracker = 0;
        }
    } 
}
