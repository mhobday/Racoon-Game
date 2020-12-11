using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLock : MonoBehaviour
{
    private void Start() {
        Lock();
    }

    public void Lock() {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Unlock() {
        Cursor.lockState = CursorLockMode.None;
    }
}
