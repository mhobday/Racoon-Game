using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMovement : MonoBehaviour
{

    private bool waiting = false;
    private float timer = 5;

    private bool move = false;

    public float timerMax = 5;

    public int position;

    public NavMeshAgent m_Agent;

    public bool tracking = false;

    private Vector3 last = new Vector3(0,0,0);

    public float turnRate = 1000;

    public bool looking = false;

    private float totalTurn = 0;

    private int testCount = 0;

    private bool destination = false;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.tag = "Enemy";
        this.m_Agent = GetComponent<NavMeshAgent>();
        this.position = 7;
    }

    // Update is called once per frame
    void Update()
    {
        if(!waiting && !tracking)
        {
            if(this.gameObject.transform.position == last && !move)
            {
                waiting = true;
                this.gameObject.GetComponent<Animator>().SetBool("Waiting", true);
            }
            else if(!destination)
            {
                m_Agent.SetDestination(EnemyPositions.positions[position]);
                move = false;
                destination = true;
            }
        }    
        else if (!tracking)
        {
            if (timer >= timerMax)
            {
                position = Random.Range(0, 8);
                timer = 0;
                waiting = false;
                move = true;
                destination = false;
                this.gameObject.GetComponent<Animator>().SetBool("Waiting", false);
            }
            else
            {
                timer += Time.deltaTime;
            }
        }
        else if(looking)
        {
            this.turn();
        }
        last = this.gameObject.transform.position;
    }

    public void Sleep ()
    {
        Destroy(this.gameObject.GetComponent<enemyVision>());
        Destroy(this);
    }

    public void Pacified ()
    {
        this.gameObject.AddComponent(System.Type.GetType("grabbableItem"));
        Destroy(this);
    }

    public void setMovement(Vector3 position)
    {
        tracking = true;
        this.gameObject.GetComponent<Animator>().SetBool("Chasing", true);
        m_Agent.SetDestination(position);
    }

    public void turn()
    {
        if(!looking)
        {
            totalTurn = 0;
            looking = true;
            testCount++;
        }
        transform.Rotate ( Vector3.up * (turnRate * Time.deltaTime ) );
        totalTurn += (turnRate * Time.deltaTime );
        if(totalTurn >= 360)
        {
            looking = false;
            tracking = false;
            this.gameObject.GetComponent<Animator>().SetBool("Chasing", false);
            totalTurn += (turnRate * Time.deltaTime );
        }
    }
}
