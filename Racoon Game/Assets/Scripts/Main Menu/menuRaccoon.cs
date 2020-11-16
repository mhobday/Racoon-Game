using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuRaccoon : MonoBehaviour
{
    //Time between peeks
    public float peekTimerMax = 10f;
    //Time until next peek
    private float peekTimer = 10f;
    //speed the raccoon comes out from behind the dumpster
    public float peekSpeed = .01f;
    //amount of time raccoon stays visible
    public float animLength = 1;
    private Vector3 target = Vector3.zero;
    private Animation animation;
    // Start is called before the first frame update
    void Start()
    {
        animation = gameObject.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        peekTimer -= Time.deltaTime;
        if(peekTimer <= 0 && !animation.isPlaying)
        {
            target = new Vector3(-3, -1, 0);
            animation.Play("Idle");
            Invoke("ResetAnimation", animLength);
        }
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, target, peekSpeed);   
    }

    private void ResetAnimation()
    {
        animation.Stop();
        target = Vector3.zero;
        peekTimer = peekTimerMax;
    }
}
