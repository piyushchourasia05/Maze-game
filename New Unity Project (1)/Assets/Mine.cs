using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class Mine : MonoBehaviour
{
    public float blastRadius = 50f;
    public float blastForce = 700f;

    public GameObject explosionEffect;
    public bool hasExploded = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider player)
    {
        if (player.tag == "Player" && !hasExploded)
        {
            Explode();
            hasExploded = true;
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
        CameraShaker.Instance.ShakeOnce(6f, 6f, .1f, 1f);

        Destroy(gameObject);

        Debug.Log("Boom!");

    }
}