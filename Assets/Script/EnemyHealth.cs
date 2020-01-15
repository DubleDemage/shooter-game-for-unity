using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float hitPoints = 100f;

    public Slider enemyHealthBar;

    bool isDead = false;

    public GameObject lootDrop;

    public bool IsDead()
    {
        return isDead;
    }

    private void Start()
    {
        lootDrop.SetActive(false);
    }

    public void Update()
    {
        enemyHealthBar.value = hitPoints;
    }

    public void TakeDamage(float damage)
    {
        GetComponent<EnemyAI>().AgroAttack();
        hitPoints -= damage;
        if(hitPoints <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (isDead)
        {
            return;
        }
        isDead = true;
        GetComponent<Animator>().SetTrigger("die");
        lootDrop.SetActive(true);
    }
       
}
