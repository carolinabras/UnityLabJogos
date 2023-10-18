using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    
    private Animator anim; // animator of player
    
    public Transform attackPoint; // position of attack
    public float attackRange = 0.5f; // range of attack
    public LayerMask enemyLayers; // layer mask of enemy
    
    public int swordDamage = 40; // damage of sword
    
    public float attackRate = 2f; // attack rate of sword
    float nextAttackTime = 0f; // time until next attack
    
    public Transform firePoint; // position of fire point
    public GameObject projectilePrefab; // projectile prefab

    
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            //if left mouse button is pressed
            if (Input.GetButtonDown("Fire1"))
            {
                AttackSword();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
        if (Input.GetButtonDown("Fire2"))
        {
            //spawn projectile
            //if player is facing right spawn projectile to the right
            if (gameObject.GetComponent<SpriteRenderer>().flipX == false)
            {
                Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            }
            //if player is facing left spawn projectile to the left
            else
            {
                Instantiate(projectilePrefab, firePoint.position, Quaternion.Euler(0, 0, 180f));
          
            }
            
        }
    }

    private void AttackSword()
    {
        //play animation
        anim.SetTrigger("Attack");
        //check if enemy is in range
        
        //if enemy is in range deal damage; attack all enemies in the radius of the circle
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        
        //damage them
        foreach (Collider2D enemy in hitEnemies)
        {
            //we now want to access the take damage function from the enemy script
            enemy.GetComponent<Enemy>().TakeDamage(swordDamage);
        }
    }
    //we can see in the editor our attack range by drawing a circle
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    
    
}
