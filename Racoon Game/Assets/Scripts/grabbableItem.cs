using cakeslice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grabbableItem : MonoBehaviour
{
    public Outline outline;
    //Scale the object will be in xyz when grabbed
    public Vector3 holdScale = new Vector3 (.0005f, .0005f, .0005f);
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
