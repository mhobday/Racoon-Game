using cakeslice;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Video;

public class racoonMovement : MonoBehaviour
{
    public float moveSpeed;
    [SerializeField]
    private Rigidbody rigidbody;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    public Animation animation;
    //All grabbable items currently within reach
    List<GameObject> currentGrabbables = new List<GameObject>();
    [SerializeField]
    //Amount of time idle before an animation is played
    private float idleTimerMax = 3;
    private float idleTimer = 3;
    //True if can grab something at the moment
    private bool holdingItem = false;
    //Current held item
    private GameObject heldItem;
    //Location of the Raccoon's head
    private GameObject head;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = this.gameObject.GetComponent<Rigidbody>();
        animator = this.gameObject.GetComponent<Animator>();
        animation = this.gameObject.GetComponent<Animation>();
        head = this.gameObject.transform.Find("Rig/root/body/Head").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontal * moveSpeed, rigidbody.velocity.y, vertical * moveSpeed);
        rigidbody.velocity = movement;
        //Runs raccoon animations
        Animate(movement);
        
    }

    void Animate(Vector3 movement)
    {
        //Checks how long the player has been idle, if longer than idleTimerMax, plays the idle animation
        if (idleTimer <= 0)
        {
            animation.Play("Idle");
            idleTimer = idleTimerMax;
        }
        else if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
        {
            idleTimer -= Time.deltaTime;
        }
        else
        {
            idleTimer = idleTimerMax;
        }
        //Walk animations
        if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            animation.Play("Walk");
            //Sets raccoon direction to the way he's walking gradually
            Vector3 temp = transform.rotation.eulerAngles;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15F);
            transform.rotation = Quaternion.Euler(temp.x, transform.eulerAngles.y, transform.eulerAngles.z);
        }
        else if(animation.IsPlaying("Walk"))
        {
            animation.Stop();
        }
        //if there is something to grab and not holding something
        if(currentGrabbables.Count > 0 && !holdingItem && Input.GetKeyDown(KeyCode.Mouse0))
        {
            animation.Stop();
            animation.Play("Munch");
            GrabObject(currentGrabbables);
        }
        else if(holdingItem && Input.GetKeyDown(KeyCode.Mouse0))
        {
            animation.Play("Munch");
            ReleaseObject();
        }
        //Hehe
        if(Input.GetKey(KeyCode.L))
        {
            animation.Play("Spin");
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Grabbable")
        {
            currentGrabbables.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Grabbable")
        {
            currentGrabbables.Remove(other.gameObject);
        }
    }

    void GrabObject(List<GameObject> currentGrabbables)
    {
        heldItem = FindClosestObject(currentGrabbables);
        currentGrabbables.Remove(heldItem);
        foreach (Collider c in heldItem.GetComponents<Collider>())
        {
            c.enabled = false;
        }
        heldItem.GetComponent<Rigidbody>().useGravity = false;
        heldItem.GetComponent<Rigidbody>().velocity = Vector3.zero;
        heldItem.transform.position = head.transform.position;
        heldItem.GetComponent<Outline>().eraseRenderer = true;
        heldItem.transform.parent = head.transform;
        heldItem.transform.localScale = heldItem.GetComponent<grabbableItem>().holdScale;
        holdingItem = true;
    }
    void ReleaseObject()
    {
        foreach (Collider c in heldItem.GetComponents<Collider>())
        {
            c.enabled = true;
        }
        heldItem.GetComponent<Rigidbody>().useGravity = true;
        heldItem.GetComponent<Rigidbody>().velocity = Vector3.zero;
        heldItem.GetComponent<Outline>().eraseRenderer = false;
        heldItem.transform.parent = null;
        heldItem.transform.localScale = Vector3.one;
        holdingItem = false;
    }

    GameObject FindClosestObject(List<GameObject> objects)
    {
        GameObject closest = null;
        float minDistance = Mathf.Infinity;
        Vector3 currentPosition = this.gameObject.transform.position;
        foreach(GameObject o in objects)
        {
            float distance = Vector3.Distance(currentPosition, o.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                closest = o;
            }
        }
        return closest;
    }
}
