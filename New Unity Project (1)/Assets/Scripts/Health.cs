using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health;


    void Update()
    {
        if(health <= 0)
        {
            TakeDamage();
        }
    }

    public void TakeDamage()
    {
        Debug.Log("Damage Taken");
        Destroy(this.gameObject);
    }
}
