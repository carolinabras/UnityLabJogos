using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // the maximum health of the player
    public int currentHealth; // the current health of the player
    public bool isDead = false; // is the player dead?
    
    [SerializeField] private Animator anim; // animator component of the player
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>(); // get animator component
        currentHealth = maxHealth; // set current health to max health   
    }
    

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Trap"))
        {
            Die();
        }
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // subtract damage from current health
        if (currentHealth <= 0) // if current health is less than or equal to 0
        {
            Die(); // die
        }
    }
    
    void Die()
    {
        //wait for 2 seconds
        //restart the game
        //can create a dying animation if you have it and then destroy the enemy
        Debug.Log("Player died!"); // log that enemy died
        anim.SetTrigger("Die");
        isDead = true;

    }
    
}
