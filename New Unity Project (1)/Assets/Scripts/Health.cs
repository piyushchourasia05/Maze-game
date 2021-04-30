using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float startHealth;
    public float health;
    public Image healthBar;

    void Start()
    {
        health = startHealth;
    }

    public void TakeDamage(int amount)
    {
        startHealth -= amount;
        healthBar.fillAmount = health / startHealth;
        if(startHealth <= 0)
        {
            Die();
        }        
    }

    public void Die()
    {
        Debug.Log("Player is dead");
    }
}
