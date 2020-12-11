using cakeslice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grabbableItem : MonoBehaviour
{
    public Outline outline;

    public int cost = 10;
    //Scale the object will be in xyz when grabbed
    public int holdScale = 2;

    public Vector3 holdRotation = Vector3.zero;
    public Vector3 holdOffset = Vector3.zero;

    void Start()
    {
        gameObject.tag = "Grabbable";
        outline = this.gameObject.GetComponent<Outline>();
    }
    //Highlight when player is near
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            outline.eraseRenderer = false;
        }

    }
    //Stop highlighting when player leaves
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            outline.eraseRenderer = true;
        }
    }
}
