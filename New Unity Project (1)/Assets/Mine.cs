using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class Mine : MonoBehaviour
{
    public float health = 40f;

    public float blastRadius = 50f;
    public float blastForce = 700f;

    public GameObject explosionEffect;
    public bool hasExploded = false;


    void OnTriggerEnter(Collider player)
    {
        if (player.tag == "Player" && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Explode();
        }
    }

    void Explode()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);

        Collider[] colliders = Physics.OverlapSphere(transform.position, blastRadius);
        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(blastForce, transform.position, blastRadius);
            }
        }
      

        Destroy(gameObject);

        Debug.Log("Boom!");

    }

}