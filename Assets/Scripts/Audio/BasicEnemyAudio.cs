using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyAudio : MonoBehaviour
{
    [SerializeField] private bool isSnakeEnemy = true;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private List<AudioClip> enemyImpactClips;
    [SerializeField] private List<AudioClip> snakeHissClips;
    [SerializeField] private List<AudioClip> minoRoarClips;
    [SerializeField] private EnemyHealthPoints enemyHealth;


    private void Start()
    {
        enemyHealth.OnHurt.AddListener(PlayEnemyImpact);
        PlayRoar();
    }

    public void PlayEnemyImpact()
    {
        AudioClip enemyImpact = enemyImpactClips[Random.Range(0, enemyImpactClips.Count)];
        RandomizeAudio();
        audioSource.PlayOneShot(enemyImpact);
    }
    public void PlayRoar()
    {
        AudioClip enemyRoar;
        if(isSnakeEnemy)
        {
            enemyRoar = snakeHissClips[Random.Range(0, snakeHissClips.Count)];
        }
        else
        {
            enemyRoar = minoRoarClips[Random.Range(0, minoRoarClips.Count)];
        }

        RandomizeAudio();
        audioSource.PlayOneShot(enemyRoar);
    }

    private void RandomizeAudio()
    {
        audioSource.volume = Random.Range(0.75f, 0.99f);
        audioSource.pitch = Random.Range(0.95f, 1.05f);
    }
}
