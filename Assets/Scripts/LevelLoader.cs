using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Script for loading levels
// This script stores the level, and the level manager loads the details of the level.
public class LevelLoader : MonoBehaviour
{
    public static string level; // Stores the level

    // Awake is called at the start of the program
    private void Awake()
    {
        DontDestroyOnLoad(gameObject); // Set this object to not destroy on switching scenes
    }
}
