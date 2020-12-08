using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowScript : MonoBehaviour
{   

    public GameObject brokenWindow;

    void Start()
    {
        this.gameObject.tag = "Window";
        open();
    }
    public void open()
    {
        this.gameObject.SetActive(false);
    }

    public void close()
    {
        this.gameObject.SetActive(true);
    }

    public void breakWindow()
    {
        float x = this.gameObject.transform.localScale.x;
        float y = this.gameObject.transform.localScale.y;
        float z = this.gameObject.transform.localScale.z;
        float yRotation = this.gameObject.transform.rotation.y;
        GameObject newWindow = Instantiate(brokenWindow, this.gameObject.transform.position, Quaternion.identity);
        if (yRotation != 0)
        {
            newWindow.transform.Rotate(0, 90, 0); 
        }
        
        Vector3 change = new Vector3(x, y, 1);
        newWindow.transform.localScale = change;
        Destroy(this.gameObject);
    }
}
