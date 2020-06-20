using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    public float damage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.TryGetComponent(out EnemyAI component);
            component?.TakeHit(damage);
        }
        else if (other.gameObject.CompareTag("PuzzlePlataform"))
        {
            other.gameObject.TryGetComponent(out PuzzlePlataform plataform);
            plataform?.ChangeState();
        }
    }
}
