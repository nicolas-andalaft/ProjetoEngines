using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public float minDist;
    private NavMeshAgent navMeshAgent;
    private Life life;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        life = GetComponent<Life>();
    }

    private void Update()
    {
        if (life.getLife() <= 0) return;

        Vector3 playerPosition = TPSWalker.floorPoint;
        navMeshAgent.SetDestination(playerPosition);
        float distance = Vector3.Distance(transform.position, playerPosition);
        if (distance < minDist)
            navMeshAgent.isStopped = true;
        else
            navMeshAgent.isStopped = false;
    }
}
