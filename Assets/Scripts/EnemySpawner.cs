using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float waveInterval;
    public float waveQtd;
    public GameObject enemyPrefab;
    public AudioSource spawnSound;
    private float time;

    private void Start()
    {
        time = waveInterval;
    }

    private void Update()
    {
        time += Time.deltaTime;
        if (time >= waveInterval)
        {
            time = 0;
            spawnSound.Play();
            for (int i = 0; i < waveQtd; i++)
            {
                Instantiate(enemyPrefab, transform.position, transform.rotation);
            }
        }
    }
}
