using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    public int eggs = 0; // the number of eggs collected
    
    [SerializeField] private TMP_Text eggText; // the text that displays the number of eggs collected
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("egg")) // if the other game object has the tag "egg"
        {
            Destroy(collision.gameObject); // destroy the egg
            eggs++; // add one to the number of eggs collected
            eggText.SetText("Eggs: " + eggs); // update the text that displays the number of eggs collected
        }
    }
}
