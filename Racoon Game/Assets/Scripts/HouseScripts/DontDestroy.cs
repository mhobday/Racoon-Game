using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    public static bool exists = false;

    void Awake()
    {
        Debug.Log("Awake");
        if (DontDestroy.exists) {
            Debug.Log("exists already");
            Destroy(this.gameObject);
        }
        DontDestroy.exists = true;
        DontDestroyOnLoad(this.gameObject);
    }
}
