using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth player;
    public float damage = 10f;
    public ParticleSystem gunFlash;

    public AudioClip arSound;
    AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerHealth>();
        audioSource = GetComponent<AudioSource>();
    }

    public void AttackHitEvent()
    {
        if (player == null) return;
        gunFlash.Play();
        audioSource.Play();
        player.TakeDamage(damage);
        Debug.Log("bang bang");
    }

}
