using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    public float speed; // speed of the projectile
    private Rigidbody2D rb; // rigidbody of the projectile
    
    private void Start()
    {
        speed = 30f; // set the speed of the projectile to 20
        rb = GetComponent<Rigidbody2D>(); // get the rigidbody of the projectile
        rb.velocity = transform.right * speed; // set the velocity of the projectile to the right
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy")) // if the other game object has the tag "Enemy"
        {
            Destroy(gameObject); // destroy this game object
            other.GetComponent<Enemy>().TakeDamage(50); // take damage
        }
    }
}
