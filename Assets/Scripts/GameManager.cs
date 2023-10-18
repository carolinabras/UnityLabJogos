using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   
    public GameObject player;
    
 
    void Start()
    {
        
         
    }
    
    void Update()
    {
     if (player.GetComponent<PlayerHealth>().isDead == true)
     {
         Debug.Log("Player is dead");
         RestartGame();
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
