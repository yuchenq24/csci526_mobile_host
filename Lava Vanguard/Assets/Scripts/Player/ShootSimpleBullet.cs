using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSimpleBullet : MonoBehaviour
{
    public GameObject bulletPrefab; 
    public Transform firePoint; 
    public float fireRate = 1f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", 0f, fireRate);


    }
    void Fire()
    {
        Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
