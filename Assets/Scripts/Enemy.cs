using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("movement")]
    public float movementSpeed = 10;
    public Transform player;

    [Header("Death")]
    public float maxHealth = 3;
    public Vector2 dmgRange = new Vector2(10, 20);

    private float healthLeft;
    private Rigidbody2D rb;
    private float inputX;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
         inputX = player.position.x;


    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        var damage = Random.Range(dmgRange.x, dmgRange.y);
        var health = other.gameObject.GetComponent<Health>();
        if (health != null) 
        {
            health.TakeDamage((int)damage);
        }
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(inputX*movementSpeed,rb.velocity.y);
    }
}
