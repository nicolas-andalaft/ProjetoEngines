using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float duration;
    public ParticleSystem particles;
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
    }
}
