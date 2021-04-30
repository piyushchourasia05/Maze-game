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
        damage = 2;
        if (other.tag == "Player")
        {
            target = other.gameObject;
            target.GetComponent<Health>().health -= damage;
            Destroy(this.gameObject);
            Damage(GetComponent<Collider>().transform);
        }
        if(other.tag == null)
        {
            damage = 2;
        }
    }

    void Damage(Transform Player)
    {
        Health p =  Player.GetComponent<Health>();

        p.TakeDamage(5);
    }
}
