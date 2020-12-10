using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyVision : MonoBehaviour
{
    public float FOVAngle = 110;
    public float maxVisionDistance = 10;
    public bool playerInSight;

    private int invisibleLayer;

    private Vector3 lastKnownPosition;
    private Renderer renderer;
    private NavMeshAgent nav;
    private SphereCollider col;
    private GameObject player;
    private Vector3 previousLastKnownPosition;

    private EnemyMovement movement;

    private Vector3 enemyPosition;
    private Vector3 playerPosition;
    private bool seenRecently = false;

    private EnemyMovement move;
    private bool turning = false;


    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        col = GetComponent<SphereCollider>();
        player = GameObject.FindGameObjectWithTag("Player");
        renderer = GetComponent<Renderer>();
        movement = this.gameObject.GetComponent<EnemyMovement>();
        invisibleLayer = 1 << 8;
        invisibleLayer = ~invisibleLayer;
        move = this.gameObject.GetComponent<EnemyMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyPosition = this.gameObject.transform.position + transform.up;
        playerPosition = player.transform.position;
        if (previousLastKnownPosition != lastKnownPosition)
        {
            previousLastKnownPosition = lastKnownPosition;
        }
        if(playerInSight)
        {
            renderer.material.color = new Color(1, 0, 0);
            movement.m_Agent.SetDestination(player.transform.position);
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
            Debug.Log("basics");
            Vector3 direction = other.transform.position - enemyPosition;
            float angle = Vector3.Angle(direction, transform.forward);
            if(Vector3.Distance(enemyPosition, playerPosition) < 5)
            {
                Debug.Log("Basics");
                seenRecently = true;
                playerInSight = false;
                RaycastHit hit;
                Debug.DrawRay(enemyPosition, direction * 500, Color.white, 0.1f);
                if(Physics.Raycast(enemyPosition, direction, out hit, col.radius, invisibleLayer))
                {
                    Debug.Log(hit.collider.gameObject.name);
                    Debug.Log(this.gameObject.transform.position + transform.up);
                    if(hit.collider.gameObject == player)
                    {
                        Debug.Log("Why");
                        playerInSight = true;
                        lastKnownPosition = player.transform.position;
                        move.tracking = true;
                        move.setMovement(lastKnownPosition);
                    }
                }
            }
            else if(angle < FOVAngle/2){

                seenRecently = true;
                playerInSight = false;
                RaycastHit hit;
                Debug.DrawRay(enemyPosition, direction.normalized, Color.white, 0.1f);
                if(Physics.Raycast(enemyPosition, direction.normalized, out hit, col.radius, invisibleLayer))
                {
                    if(hit.collider.gameObject == player)
                    {
                        playerInSight = true;
                        lastKnownPosition = player.transform.position;
                        move.tracking = true;
                        move.setMovement(lastKnownPosition);
                    }
                }
            }
            else if(Vector3.Distance(enemyPosition, playerPosition) < 10 && seenRecently){
                playerInSight = false;
                RaycastHit hit;
                Debug.DrawRay(enemyPosition, direction.normalized, Color.white, 1f);
                if(Physics.Raycast(enemyPosition, direction.normalized, out hit, col.radius, invisibleLayer))
                {
                    if(hit.collider.gameObject == player)
                    {
                        playerInSight = true;
                        lastKnownPosition = player.transform.position;
                        move.tracking = true;
                        move.setMovement(lastKnownPosition);
                    }
                }
            }
            else if (seenRecently)
            {
                move.turn();
                seenRecently = false;
            }
            else if(move.looking)
            {

            }
            else
            {
                seenRecently = false;
                move.tracking = false;
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
