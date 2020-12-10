﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public bool locked = false;
    public float cooldown = 2;
    public float distanceToActivate = 5;
    public Vector3 position;

    private bool isOpen;
    private bool isOpening;
    private bool isClosing;

    void Start()
    {
        float rotateAxisx = this.gameObject.GetComponent<MeshRenderer>().bounds.size.x / 2;
        this.position = this.gameObject.transform.position;
        this.gameObject.tag = "Door";
        this.locked = false;
        this.isOpen = false;
        this.isOpening = false;
        this.isClosing = false;
        // this.Open();
    }

    // Update is called once per frame
    public void Open()
    {

        if(!locked && !isOpen && !isOpening)
        {
            this.gameObject.transform.RotateAround(this.position ,Vector3.up, 90);
            Debug.Log(this.position);
            Debug.Log("opened");
            Invoke("Opened", cooldown);
            isOpening = true;
        }
    }

    private void Opened() {
        isOpening = false;
        isOpen = true;
    }

    public void Close()
    {
        if (isOpen && !isClosing) {
            this.gameObject.transform.RotateAround(this.position ,Vector3.up, -90);
            Invoke("Closed", cooldown);
            isClosing = true;
        }
    }

    private void Closed() {
        isClosing = false;
        isOpen = false;
    }

    public void enemyOpen()
    {
        this.gameObject.transform.RotateAround(this.position ,Vector3.up, 90);
    }

    public bool getIsOpen() {
        return isOpen;
    }
}
