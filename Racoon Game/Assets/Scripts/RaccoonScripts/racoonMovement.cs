using cakeslice;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.Video;

public class racoonMovement : MonoBehaviour
{
    public float moveSpeed;
    //Assumed distance from raccoon to ground for checking if you can jump
    public float distanceToGround = 1;
    //Height of the jump
    public float jumpHeight = 10;
    //Delay before jump
    public float jumpDelay = .5f;
    [SerializeField]
    private Rigidbody rigidbody;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    public Animation animation;
    [SerializeField]
    public Transform camera;
    //All grabbable items currently within reach
    List<GameObject> currentGrabbables = new List<GameObject>();
    [SerializeField]
    //Amount of time idle before an animation is played
    private float idleTimerMax = 3;
    private float idleTimer = 3;
    //True if can grab something at the moment
    public bool holdingItem = false;
    //Current held item
    public GameObject heldItem;
    //Text displaying current item
    public Text itemText;
    //Location of the Raccoon's head
    private GameObject head;
    //Index of the purchased item that is currently selected by the user.
    private int selectedPurchasedItem = 0;
    public bool box = false;
    private PurchasedItem[] purchasedItems;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Player";
        rigidbody = this.gameObject.GetComponent<Rigidbody>();
        animator = this.gameObject.GetComponent<Animator>();
        animation = this.gameObject.GetComponent<Animation>();
        head = this.gameObject.transform.Find("Rig/root/body/Head").gameObject;
        purchasedItems = GetComponents<PurchasedItem>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 movement = new Vector3(horizontal * moveSpeed, rigidbody.velocity.y, vertical * moveSpeed);
        float targetAngle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg + camera.eulerAngles.y;
        Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        if(horizontal != 0 || vertical != 0)
        {
            Vector3 temp = new Vector3(0f, rigidbody.velocity.y, 0f);
            rigidbody.velocity = moveDir.normalized * moveSpeed;
            rigidbody.velocity += temp;
        }
        //Runs raccoon animations
        Animate(moveDir);

    }

    void Animate(Vector3 moveDir)
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
        if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            if(!animation.IsPlaying("Jump") || !animation.IsPlaying("Munch"))
            {
                animation.Play("Walk");
            }
            //Sets raccoon direction to the way he's walking gradually
            Vector3 temp = transform.rotation.eulerAngles;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveDir), 0.15F);
            transform.rotation = Quaternion.Euler(temp.x, transform.eulerAngles.y, transform.eulerAngles.z);
        }
        else if(animation.IsPlaying("Walk"))
        {
            animation.Stop();
        }
        //Jump
        //Delayed jump is an option but it feels a bit janky
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Invoke("Jump", jumpDelay);
            animation.Stop();
            animation.Play("Jump");
        }
        //Grab
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

        //Open Door
        if (Input.GetKey(KeyCode.E)) {
            GameObject[] doors = GameObject.FindGameObjectsWithTag("Door");
            foreach (GameObject door in doors)
            {
                DoorScript doorScript = door.GetComponent<DoorScript>();
                if (Vector3.Distance(transform.position, door.transform.position) < doorScript.distanceToActivate) {
                    if (!doorScript.getIsOpen()) {
                        doorScript.Open();
                    } else {
                        doorScript.Close();
                    }
                }
            }
        }

        //Use item
        if (Input.GetKeyDown(KeyCode.Mouse1)) {
            if (purchasedItems.Length > 0) {
                purchasedItems[selectedPurchasedItem].use();
            }
        }

        //Swap item up
        if (Input.GetAxis("Mouse ScrollWheel") > 0 && purchasedItems.Length > 0) {
            selectedPurchasedItem = (selectedPurchasedItem + 1) % purchasedItems.Length;
            Debug.Log(purchasedItems[selectedPurchasedItem].GetType().Name);
            itemText.text = purchasedItems[selectedPurchasedItem].GetType().Name;
        }

        //Swap item down
        if (Input.GetAxis("Mouse ScrollWheel") < 0 && purchasedItems.Length > 0) {
            selectedPurchasedItem = (selectedPurchasedItem + purchasedItems.Length - 1) % purchasedItems.Length;
            Debug.Log(purchasedItems[selectedPurchasedItem].GetType().Name);
            itemText.text = purchasedItems[selectedPurchasedItem].GetType().Name;
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
        heldItem = FindClosestObjectTo(currentGrabbables, head.transform.position);
        grabbableItem heldItemScript = heldItem.GetComponent<grabbableItem>();
        currentGrabbables.Remove(heldItem);
        foreach (Collider c in heldItem.GetComponents<Collider>())
        {
            c.enabled = false;
        }
        heldItem.GetComponent<Rigidbody>().useGravity = false;
        heldItem.GetComponent<Rigidbody>().isKinematic = true;
        heldItem.GetComponent<Rigidbody>().velocity = Vector3.zero;
        heldItem.transform.rotation = Quaternion.Euler(
            head.transform.rotation.x + heldItemScript.holdRotation.x,
            head.transform.rotation.y + heldItemScript.holdRotation.y,
            head.transform.rotation.z + heldItemScript.holdRotation.z);
        heldItem.transform.position = head.transform.position + heldItemScript.holdOffset;
        heldItem.GetComponent<cakeslice.Outline>().eraseRenderer = true;
        heldItem.transform.parent = head.transform;
        heldItem.transform.localScale = heldItem.transform.localScale / heldItemScript.holdScale;
        holdingItem = true;
    }
    void ReleaseObject()
    {
        foreach (Collider c in heldItem.GetComponents<Collider>())
        {
            c.enabled = true;
        }
        heldItem.GetComponent<Rigidbody>().useGravity = true;
        heldItem.GetComponent<Rigidbody>().isKinematic = false;
        heldItem.GetComponent<Rigidbody>().velocity = Vector3.zero;
        heldItem.GetComponent<cakeslice.Outline>().eraseRenderer = false;
        heldItem.transform.parent = null;
        heldItem.transform.localScale = heldItem.transform.localScale * heldItem.GetComponent<grabbableItem>().holdScale;
        heldItem = null;
        holdingItem = false;
    }

    GameObject FindClosestObjectTo(List<GameObject> objects, Vector3 location)
    {
        GameObject closest = null;
        float minDistance = Mathf.Infinity;
        Vector3 currentPosition = this.gameObject.transform.position;
        foreach(GameObject o in objects)
        {
            float distance = Vector3.Distance(location, o.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                closest = o;
            }
        }
        return closest;
    }

    bool IsGrounded()
    {
        return Physics.Raycast(new Vector3(transform.position.x, transform.position.y + .1f, transform.position.z), Vector3.down, distanceToGround + 0.2f);
    }
    void Jump()
    {
        rigidbody.velocity = new Vector3(rigidbody.velocity.x, rigidbody.velocity.y + jumpHeight, rigidbody.velocity.z);
    }
}
