using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public float startHealth;
    public float health;
    public Image healthBar;

    void Start()
    {
        health = startHealth;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        healthBar.fillAmount = health / startHealth;
        if (health <= 0)
        {
            Die();
            SceneManager.LoadScene(8);
        }        
    }

    public void Die()
    {
        Debug.Log("Player is dead");
    }
}
