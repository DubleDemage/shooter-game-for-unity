using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth player;
    public float damage = 10f;
    public ParticleSystem gunFlash;


    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerHealth>();
    }

    public void AttackHitEvent()
    {
        if (player == null) return;
        gunFlash.Play();
        player.TakeDamage(damage);
        Debug.Log("bang bang");
    }

}
