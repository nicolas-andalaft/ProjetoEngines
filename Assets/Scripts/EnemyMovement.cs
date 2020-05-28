using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public float minDist;
    private NavMeshAgent navMeshAgent;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        Vector3 playerPosition = FPSWalker.floorPoint;
        navMeshAgent.SetDestination(playerPosition);
        float distance = Vector3.Distance(transform.position, playerPosition);
        if (distance < minDist)
            navMeshAgent.isStopped = true;
        else
            navMeshAgent.isStopped = false;
    }
}
