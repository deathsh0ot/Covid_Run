using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSneeze : MonoBehaviour
{
    public Transform SneezePoint;
    public GameObject bulletPrefab;
    public float fireRate = 1f;
    float nextFire;
    // Update is called once per frame
    void Start()
    {
        nextFire = Time.time;
    }
    void Update()
    {
        Shoot();
    }
    void Shoot()
    {
        if (Time.time > nextFire)
        {
            Instantiate(bulletPrefab, SneezePoint.position, SneezePoint.rotation);
            nextFire = Time.time + fireRate;
        }

    }
}