using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
   public bool nextLevel = false; // boolean to check if the next level should be loaded
   
   private void OnCollisionEnter2D(Collision2D other)
   {
      if (other.gameObject.CompareTag("NextLevel")) // if the other game object has the tag "Player"
      {
         nextLevel= true; // load the next scene in the build index
      }
   }
}
