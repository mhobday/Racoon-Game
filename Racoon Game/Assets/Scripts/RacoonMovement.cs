using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacoonMovement : MonoBehaviour
{
    public float moveSpeed;
    [SerializeField]
    private Rigidbody rigidbody;
    [SerializeField]
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = this.gameObject.GetComponent<Rigidbody>();
        animator = this.gameObject.GetComponent<Animator>();
        animator.Play("Idle");
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.velocity = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, rigidbody.velocity.y, Input.GetAxis("Vertical") * moveSpeed);
        
    }


}
