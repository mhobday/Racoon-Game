using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyVision : MonoBehaviour
{
    public float FOVAngle = 110;
    public float maxVisionDistance = 10;
    public bool playerInSight;
    
    private Vector3 lastKnownPosition;
    private Renderer renderer;
    private NavMeshAgent nav;
    private SphereCollider col;
    private GameObject player;
    private Vector3 previousLastKnownPosition;
    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        col = GetComponent<SphereCollider>();
        player = GameObject.FindGameObjectWithTag("Player");
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (previousLastKnownPosition != lastKnownPosition)
        {
            previousLastKnownPosition = lastKnownPosition;
        }
        if(playerInSight)
        {
            renderer.material.color = new Color(1, 0, 0);
        }
        else
        {
            renderer.material.color = new Color(1, 1, 1);
        }
    }
    //Checks if player is in vision sphere, in the vision angle and not behind something if true playersight = true otherwise false
    //Also has options for hearing the player as well
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject == player)
        {
            playerInSight = false;
            Vector3 direction = other.transform.position - transform.position;
            float angle = Vector3.Angle(direction, transform.forward);
            if(angle < FOVAngle/2)
            {
                RaycastHit hit;
                if(Physics.Raycast(transform.position + transform.up, direction.normalized, out hit, col.radius))
                {
                    if(hit.collider.gameObject == player)
                    {
                        playerInSight = true;
                        lastKnownPosition = player.transform.position;
                    }
                }
            }
        }
        //In the future could add code to test what is playing audio and ignore some, could also ignore certain sounds that are just for fun.
        if(other.gameObject.GetComponent<AudioSource>() != null && other.gameObject.GetComponent<AudioSource>().isPlaying)
        {
            lastKnownPosition = other.gameObject.transform.position;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        playerInSight = false;
    }
}
