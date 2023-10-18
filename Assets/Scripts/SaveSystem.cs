using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public string playerHealthKey = "playerHealth", sceneKey = "SceneIndex", savePresentKey = "SavePresent";
    
}

public class LoadedData
{
    public int playerHealth = -1;
    public int sceneIndex = -1;
    public bool savePresent;
}
