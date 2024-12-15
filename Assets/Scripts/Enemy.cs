using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("movement")]
    public float movementSpeed = 10;
    public Transform player;
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
    void FixedUpdate()
    {
        rb.velocity = new Vector2(inputX*movementSpeed,rb.velocity.y);
    }
}
