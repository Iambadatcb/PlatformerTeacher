using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float shotCooldown = 0.2f;
    public AudioClip AudioClip;
    public AudioSource hand;
    
    private float shotCooldownTime;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = hand;
    }


    void Update()
    {
        
        
            
        
        if (Input.GetMouseButtonDown(0)&& shotCooldownTime<=0){
            
            audioSource.clip = AudioClip;
            audioSource.Play();
            shotCooldownTime = shotCooldown;
        
        
            var mousePos = Input.mousePosition;
            var worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            worldPos.z = 0;
            var direction = worldPos - transform.position;
            direction.Normalize();

            var bullet = Instantiate(bulletPrefab,firePoint.position,Quaternion.identity);
            bullet.GetComponent<Bullet>().direction = direction;
            bullet.GetComponent<Bullet>().clip = AudioClip;
            
        }
        shotCooldownTime-=Time.deltaTime;
    }
}
