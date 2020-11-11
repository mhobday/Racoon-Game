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
            Vector3 temp = this.gameObject.transform.position;
            temp.x += 1.0f;
            this.gameObject.transform.position = temp;
            positionTracker++;
        } else if (!right && positionTracker < distance) {
            Vector3 temp = this.gameObject.transform.position;
            temp.x -= 1.0f;
            this.gameObject.transform.position = temp;
            positionTracker++;
        } else {
            right = !right;
            positionTracker = 0;
        }
    } 
}
