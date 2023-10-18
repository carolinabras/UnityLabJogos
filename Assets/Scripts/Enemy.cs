using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 200; // max health of enemy
    public int currentHealth; // current health of enemy
    public int basicDamage = 40; // basic damage of enemy
    [SerializeField] private GameObject player; // player game object
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth; // set current health to max health
       
        
    }
    

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // subtract damage from current health
        if (currentHealth <= 0) // if current health is less than or equal to 0
        {
            Die(); // die
        }
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player")) // if the other game object has the tag "Player"
        {
            other.gameObject.GetComponent<PlayerHealth>().TakeDamage(basicDamage); // take damage
        }
    }


    void Die()
    {
        //can create a dying animation if you have it and then destroy the enemy
        Debug.Log("Enemy died!"); // log that enemy died
        Destroy(gameObject); // destroy enemy
    }
}
