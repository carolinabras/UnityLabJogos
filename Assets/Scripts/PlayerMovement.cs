using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb; // rigidbody of player; only this script can access it
    private BoxCollider2D collider; // collider of player
    private Animator anim; // animator of player

    private float dirX = 0;
    
    public float timeOffGround = 0f;

    private SpriteRenderer sprite; // sprite of player
    
    [SerializeField] private float jumpForce = 14f; // jump force of player
    [SerializeField] private float moveSpeed = 7f; // move speed of player
    
    [SerializeField] private LayerMask jumpableGround; // layer mask of ground
    
    private enum MovementState { idle, running, jumping, falling } // movement states of player
    
    
    public bool falling = false;
    
    // Start is called before the first frame update
    void Start()
    {
        // initialize rigidbody
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        collider = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        //add direction X
        dirX = Input.GetAxisRaw("Horizontal"); // with raw we stop imediate movement
        rb.velocity = new Vector3(dirX * moveSpeed, rb.velocity.y, 0);
        
        /*add direction Y for not platformer game 
        float dirY = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector3(rb.velocity.x, dirY * 7f, 0);*/
        
      
        //check if specific key is pressed
        if (Input.GetButtonDown("Jump") && isGrounded()) // only works for space key DOWN (not held)
        {
           rb.velocity = new Vector3(rb.velocity.x,jumpForce,0);
        }
        
        if (!isGrounded())
        {
            timeOffGround += Time.deltaTime;
        }
        else
        {
            timeOffGround = 0f;
        }

         //Check if the player has been off the ground for 3 seconds continuously
        if (timeOffGround >= 2f)
        {
            falling = true;
        }

        UpdateAnimationState();
        
        
    }

    private void UpdateAnimationState()
    {
        MovementState state;
        if (dirX > 0) {
            state = MovementState.running;
            sprite.flipX = false; // flip sprite on the X axis
        }
        else if (dirX < 0) // running in the other direction 
        {
            state = MovementState.running;
            sprite.flipX = true; // flip sprite on the X axis 

        }
        else // player is not moving; switch to idle animation
        {
            state = MovementState.idle;
        }
        
        //jummping
        if (rb.velocity.y > .1f) // if player is moving up
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f) // if player is moving down
        {
            state = MovementState.falling;
        }
        
        anim.SetInteger("state", (int)state);
    }

    private bool isGrounded()
    {
       return Physics2D.BoxCast(collider.bounds.center, 
           collider.bounds.size, 0f, Vector2.down, .1f, jumpableGround); // creates a new box (like the box collider) and checks if it is overlaping with the terrain
    }

   
    
}
