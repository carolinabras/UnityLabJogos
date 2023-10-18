using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   
    public GameObject player;
    public Animator anim;
    
    
    void Update()
    {
     if (player.GetComponent<PlayerHealth>().isDead == true)
     {
         Debug.Log("Player is dead");
         //wait for 2 seconds then call restart game
         anim.SetTrigger("Die");
         Invoke("RestartGame", 2f); // this is very ugly but it kinda works? 
         
         
         
     }
     
     if (player.GetComponent<PlayerMovement>().falling == true)
     {
         Debug.Log("Player is falling");
         RestartGame();
     }

     if (player.GetComponent<NextLevel>().nextLevel == true)
     {
         LoadNextLevel();
     }
     
    }
    
    

    void RestartGame()
    {
        Debug.Log("Restarting game");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    void LoadNextLevel()
    {
        Debug.Log("Loading next level");
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    
}
