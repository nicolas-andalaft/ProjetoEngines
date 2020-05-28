using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float duration;
    public ParticleSystem particles;
    public float damage;
    private float time = 0;

    private void Update()
    {
        time += Time.deltaTime;
        if (time >= duration)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        particles.Play();
        if (collision.gameObject.tag == "Enemy")
        {
            Life lifeComp = collision.gameObject.GetComponent<Life>();
            lifeComp.decreaseLife(damage);
        }
    }
}
