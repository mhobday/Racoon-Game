using System.Collections;
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
        this.Open();
    }

    // Update is called once per frame
    void Open()
    {
        
        if(!locked)
        {
            this.gameObject.transform.RotateAround(this.position ,Vector3.up, 90);
        }
    }

    void close()
    {
        this.gameObject.transform.RotateAround(this.position ,Vector3.up, -90);
    }
}
