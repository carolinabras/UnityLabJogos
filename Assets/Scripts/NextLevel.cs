using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
   private void OnCollisionEnter2D(Collision2D other)
   {
      if (other.gameObject.CompareTag("Player")) // if the other game object has the tag "Player"
      {
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1); // load the next scene in the build index
      }
   }
}
