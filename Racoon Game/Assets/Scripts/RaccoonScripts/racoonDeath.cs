using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class racoonDeath : MonoBehaviour
{
    public AudioClip GameOver;
    public Camera camera;

    private void OnCollisionEnter(Collision other) {

        Debug.Log("test");
        if(other.gameObject.CompareTag("Enemy"))
        {
            this.gameObject.GetComponent<Animation>().Play("Death");
            this.gameObject.GetComponent<racoonMovement>().enabled = false;
            StartCoroutine(EndGame(3.0f));
        }
    }

    IEnumerator EndGame(float waitTime) {
        AudioClip temp = camera.GetComponent<AudioSource>().clip;
        camera.GetComponent<AudioSource>().clip = GameOver;
        camera.GetComponent<AudioSource>().Play();
        camera.GetComponent<AudioSource>().loop = false;
        yield return new WaitForSeconds(waitTime);
        camera.GetComponent<AudioSource>().clip = temp;
        camera.GetComponent<AudioSource>().loop = true;
        SaveLoad.Save();
        MenuLoader.GoToMenu(MenuName.Main);
    }
}
