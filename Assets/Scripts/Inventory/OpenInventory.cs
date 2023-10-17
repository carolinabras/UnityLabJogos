using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenInventory : MonoBehaviour
{
    public GameObject mainInventory; // main inventory game object
    public void Start()
    {
        mainInventory.SetActive(false); // deactivate this game object
    }
    public void Update()
    {
        // if the player presses the "X key activate this game object. if player presses escape deactivate this game object
        if (Input.GetKeyDown(KeyCode.X))
        {
            mainInventory.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            mainInventory.SetActive(false);
        }
    }
}
