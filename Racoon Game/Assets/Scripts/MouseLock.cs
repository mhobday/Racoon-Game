using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLock : MonoBehaviour
{
    private void Start() {
        Cursor.lockState = CursorLockMode.Locked;
    }  
}
