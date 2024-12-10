using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 direction;
    public float speed = 30;
    public float lifeTime = 2;
    

    public Vector2 dmgRange = new Vector2(10,20);

    private Rigidbody2D rb;
    private AudioSource audioSource;
    public AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = direction * speed;
    }
    private void OnCollisionEnter2D(Collision2D other){
        var damage = Random.Range(dmgRange.x,dmgRange.y);
        var health = other.gameObject.GetComponent<Health>();
        if(health != null)
        {
            health.TakeDamage((int) damage);
        }

        audioSource.clip = clip;
        audioSource.Play();
        
        Destroy(gameObject);
    }
}
