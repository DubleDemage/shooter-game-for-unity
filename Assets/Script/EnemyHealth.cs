using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float hitPoints = 100f;

    public Slider enemyHealthBar;

    public void Update()
    {
        enemyHealthBar.value = hitPoints;
    }

    public void TakeDamage(float damage)
    {
        GetComponent<EnemyAI>().OnDamageTake();
        hitPoints -= damage;
        if(hitPoints <= 0)
        {
            Destroy(gameObject);
        }
    }
       
}
