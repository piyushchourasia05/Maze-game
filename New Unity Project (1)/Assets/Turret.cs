using UnityEngine;
using EZCameraShake;

public class Turret : MonoBehaviour
{

    public float health = 100f;

    public float blastRadius = 100f;
    public float blastForce = 70f;

    public GameObject explosionEffect;
    public bool hasExploded = false;

    public void TakeDamage (float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            TurretExplode();
        }
    }


    void TurretExplode()
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
        CameraShaker.Instance.ShakeOnce(0.5f, 1f, .1f, 1f);

        Destroy(gameObject);

        Debug.Log("Turret Destroyed");

    }

}
