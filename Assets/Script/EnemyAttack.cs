using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth player;
    public float damage = 10f;
    public ParticleSystem gunFlash;

    AudioSource audioSource;
    AudioClip arSound;

    private void Start()
    {
        player = FindObjectOfType<PlayerHealth>();
        audioSource = GetComponent<AudioSource>();
    }

    public void AttackHitEvent()
    {
        if (player == null) return;
        gunFlash.Play();
        player.TakeDamage(damage);
        audioSource.Play();
    }
}
