using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    public float movementSpeed = 10;
    public float jumpHeight = 3;
    public float dashSpeed = 30;
    public float dashDur = 0.2f;
    public float dashCooldown = 1f;
    
    [Header("Jump")]
    public Transform groundCheck; //player legs
    public LayerMask groundLayer;
    public float groundCheckRadius = 0.2f;
    public int maxJumps = 1;
    
    [Header("Jump Mechanics")]
    public float coyoteTime = 0.3f;
    [Header("Health")]
    public float maxHealth = 3;


   
    private float coyoteTimeCounter;
    private bool isGrounded;
    private Rigidbody2D rb;
    private float inputX;
    private int jumpLeft;
    private bool isDashing;
    private float dashTime;
    private float dashCooldownTime;
    private float healthLeft;
    

    
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        healthLeft = maxHealth;
    }

    void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        
        if(isGrounded)
        {
            
            coyoteTimeCounter = coyoteTime;
            jumpLeft = maxJumps;
        }
        else{
            coyoteTimeCounter-= Time.deltaTime;
        }
        
        if ((coyoteTimeCounter>0 || jumpLeft >0) && Input.GetKeyDown(KeyCode.Space))
        {
            var jumpVelocity = Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y * rb.gravityScale);
            
            rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);

            if(!isGrounded){
                jumpLeft--;
            }
            
        }
        //Dash
        if(Input.GetKeyDown(KeyCode.LeftShift)&& dashCooldownTime <=0){
            isDashing = true;
            dashTime = dashDur;
            dashCooldownTime = dashCooldown;
        }

        if(isDashing){
            rb.velocity = new Vector2(inputX * dashSpeed, rb.velocity.y);
            dashTime-=Time.deltaTime;
            if(dashTime <=0){
                isDashing = false;
            }
        }
        dashCooldownTime-=Time.deltaTime;
        //Health
        

        
    }

    private void FixedUpdate()
    {
        
        if(!isDashing)
        {

        rb.velocity = new Vector2(inputX * movementSpeed, rb.velocity.y);
        }
        
    }
}
