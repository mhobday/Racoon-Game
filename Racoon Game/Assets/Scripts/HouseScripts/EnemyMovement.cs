using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMovement : MonoBehaviour
{

    private bool waiting = false;
    private float timer = 0;

    private bool move = false;

    public float timerMax = 5;

    public int position;

    public NavMeshAgent m_Agent;

    public bool tracking = false;

    private Vector3 last;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.tag = "Enemy";
        this.m_Agent = GetComponent<NavMeshAgent>();
        this.position = Random.Range(0, 8);
    }

    // Update is called once per frame
    void Update()
    {
        if(!waiting && !tracking)
        {
            if(this.gameObject.transform.position == last && !move)
            {
                waiting = true;
            }
            else
            {
                m_Agent.SetDestination(EnemyPositions.positions[position]);
                move = false;
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
            }
            else
            {
                timer += Time.deltaTime;
            }
        }
        last = this.gameObject.transform.position;
    }

    public void Sleep ()
    {
        Destroy(this);
    }

    public void Pacified ()
    {
        this.gameObject.AddComponent(System.Type.GetType("grabbableItem"));
        Destroy(this);
    }

    public void setMovement()
    {

    }
}
