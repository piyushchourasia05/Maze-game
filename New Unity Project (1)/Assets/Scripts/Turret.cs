using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private GameObject target;
    private bool targetLocked;
    public GameObject partToRotate;

    public float fireTimer;
    public GameObject firePoint;
    private bool shotReady = true;
    public GameObject bulletPrefab;

    void Update()
    {
        //Aiming and Shooting
        if (targetLocked)
        {
            partToRotate.transform.LookAt(target.transform);

            if (shotReady)
            {
                Shoot();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            target = other.gameObject;
            targetLocked = true;
        }
    }

    void Shoot()
    {
        Transform bullet = Instantiate(bulletPrefab.transform, firePoint.transform.position, Quaternion.identity);
        bullet.transform.rotation = firePoint.transform.rotation;
        shotReady = false;
        StartCoroutine(FireRate());
    }

    IEnumerator FireRate()
    {
        yield return new WaitForSeconds(fireTimer);
        shotReady = true;
    }
}
