using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    //option to add as many waypoints as we want
    [SerializeField] private GameObject[] waypoints; // creates an array of game objects called waypoints
    private int currentWaypoint = 0; // current waypoint we are at
    
    //speed of the platform
    [SerializeField] private float speed = 2f; // speed of platform
    
    private SpriteRenderer sprite; // sprite of the game object
    
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>(); // get the sprite renderer component
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(waypoints[currentWaypoint].transform.position, transform.position) < 0.1f) // if we are close to the waypoint
        {
            currentWaypoint++; // go to the next waypoint
            if (currentWaypoint >= waypoints.Length) // if we are at the last waypoint
            {
                currentWaypoint = 0; // go back to the first waypoint
            }
        }
        //if tag is enemy flips the sprite on the X axis
        if (gameObject.CompareTag("Enemy"))
        {
            if (waypoints[currentWaypoint].transform.position.x > transform.position.x)
            {
                sprite.flipX = false; // flip sprite on the X axis
            }
            else
            {
                sprite.flipX = true; // flip sprite on the X axis
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypoint].transform.position, speed * Time.deltaTime); // move towards the current waypoint
    }
    
    
}
