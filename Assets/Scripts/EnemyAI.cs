using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public enum StateAI { Walking, Attacking, Dying, GotHit }

    public float attackPower;
    public Animation animation;
    private NavMeshAgent navMeshAgent;
    private Life life;
    private Life playerLife;
    public StateAI state;
     
    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        life = GetComponent<Life>();
        playerLife = GameObject.FindGameObjectWithTag("Player").GetComponent<Life>();
    }

    private void Update()
    {
        if (life.getLife() <= 0)
        {
            Destroy(gameObject);
            return;
        }

        if (navMeshAgent.isStopped)
        {
            state = StateAI.Attacking;
            animation.Play("Anim_Attack");
            playerLife.decreaseLife(attackPower * Time.deltaTime);
        }
        else
        {
            state = StateAI.Walking;
            animation.Play("Anim_Run");
        }
    }
}
