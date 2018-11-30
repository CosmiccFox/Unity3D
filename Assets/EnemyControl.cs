using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyControl : MonoBehaviour
{
    public Transform[] waypoints;

    private int dest = 0;
    private NavMeshAgent agent;
    //public Transform target;

	// Use this for initialization
	void Start ()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;

        NextPoint();
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //GetComponent<NavMeshAgent>().SetDestination(target.position);

        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            NextPoint();
        }

    }

    void NextPoint()
    {
        if (waypoints.Length == 0)
        {
            return;
        }

        agent.destination = waypoints[dest].position;

        dest = (dest + 1) % waypoints.Length;
    }

    public void KillEnemy()
    {
        Destroy(gameObject);
    }

}
