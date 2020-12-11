using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseLock : MonoBehaviour
{
    private void Start() {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "MainMenu")
        {
            Unlock();
        }
        else
        {
            Lock();
        }
    }

    public void Lock() {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Unlock() {
        Cursor.lockState = CursorLockMode.None;
    }
}
