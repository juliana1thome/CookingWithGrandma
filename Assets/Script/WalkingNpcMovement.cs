using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkingNpcMovement : MonoBehaviour
{
    public GameObject destination;
    public NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();// Cache
        agent.destination = destination.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.destination == destination.transform.position)
        {
            agent.SetDestination(destination.transform.position);
        }
    }
}
