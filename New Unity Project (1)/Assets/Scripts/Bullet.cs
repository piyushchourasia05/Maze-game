using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float movementSpeed;
    private GameObject target;
    public float damage;

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<Health>().TakeDamage(damage);

            Destroy(this.gameObject);
        }
    }
}
