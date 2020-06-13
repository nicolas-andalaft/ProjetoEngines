using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    public float damage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.TryGetComponent(out EnemyAI component);
            if (component)
                component.TakeHit(damage);
        }
    }
}
