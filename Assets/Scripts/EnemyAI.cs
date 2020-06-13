using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public enum StateAI { Walking, Attacking, Dying, GotHit }

    public float attackPower;
    public Animation animation;
    public StateAI state;
    public GameObject deathParticles;
    public AudioSource attackSound;
    public AudioSource dieingSound;
    public AudioSource hitSound;

    private NavMeshAgent navMeshAgent;
    private Life life;
    private Life playerLife;
    private bool isDieing = false;
     
    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        life = GetComponent<Life>();
        playerLife = GameObject.FindGameObjectWithTag("Player").GetComponent<Life>();
        animation.wrapMode = WrapMode.Once;
    }

    private void Update()
    {
        if (life.getLife() <= 0)
        {
            if (!isDieing)
            {
                isDieing = true;
                animation.Play("Anim_Death");
                dieingSound.Play();
                deathParticles.SetActive(true);
                Destroy(gameObject, animation.clip.length);
            }
            return;
        }

        if (navMeshAgent.isStopped)
        {
            state = StateAI.Attacking;
            if (!animation.isPlaying)
            {
                animation.Play("Anim_Attack");
                playerLife.decreaseLife(attackPower * Time.deltaTime);
                attackSound.Play();
            }
        }
        else
        {
            state = StateAI.Walking;
            if (!animation.isPlaying)
                animation.Play("Anim_Run");
        }
    }

    public void TakeHit(float damage)
    {
        if (isDieing) return;

        hitSound.Play();
        life.decreaseLife(damage);
        animation.Play("Anim_Damage");
    }
}
