using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float hitPoints = 100f;

    public Slider healthBar;

    public int healthAmount = 10;

    public void Update()
    {
        healthBar.value = hitPoints;
    }

    public void TakeDamage(float damage)
    {
        hitPoints -= damage;
        if(hitPoints <= 0)
        {
            GetComponent<DeathHandler>().HandleDeath();
        }
    }

    public void AddHealth()
    {
        hitPoints = hitPoints + healthAmount;
    }

}
