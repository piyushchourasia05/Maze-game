using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class Explosion : MonoBehaviour
{
    public float health = 40f;

    public float blastRadius = 50f;
    public float blastForce = 700f;

    public GameObject explosionEffect;
    public bool hasExploded = false;
    public AudioClip _sound;    // this lets you drag in an audio file in the inspector
    private AudioSource audio;


    void OnTriggerEnter(Collider Player)
    {
        if (Player.tag == "Player" && !hasExploded)
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
        audio = gameObject.AddComponent<AudioSource>(); //adds an AudioSource to the game object this script is attached to
        audio.clip = _sound;
        audio.Play();
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