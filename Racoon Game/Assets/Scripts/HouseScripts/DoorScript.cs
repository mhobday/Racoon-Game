﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    // Start is called before the first frame update
    public bool locked = false;

    public Vector3 position;

    void Start()
    {
        float rotateAxisx = this.gameObject.GetComponent<MeshRenderer>().bounds.size.x / 2;
        this.position = this.gameObject.transform.position;
        this.position.x += rotateAxisx;
        this.gameObject.tag = "Door";
    }

    // Update is called once per frame
    public void Open()
    {
        
        if(!locked)
        {
            this.gameObject.transform.RotateAround(this.position ,Vector3.up, 90);
        }
    }

    public void close()
    {
        this.gameObject.transform.RotateAround(this.position ,Vector3.up, -90);
    }
}
