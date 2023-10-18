using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] private GameObject door; // the door to be opened

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player")) // if the other game object has the tag "Player"
        {
            Destroy(door); // destroy the door
            Destroy(this.gameObject);
        }
    }

}