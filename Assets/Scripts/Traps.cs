using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traps : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float shotCooldown = 0.2f;

    private float shotCooldownTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && shotCooldownTime <= 0)
        {

            
            shotCooldownTime = shotCooldown;


            
            var direction = transform.position;
            direction.Normalize();

            var bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            bullet.GetComponent<Bullet>().direction = direction;
            

        }
        shotCooldownTime -= Time.deltaTime;
    }
}
