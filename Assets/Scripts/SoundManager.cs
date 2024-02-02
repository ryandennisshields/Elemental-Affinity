using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script for sound management
// This script stores sounds for other code to use.
public class SoundManager : MonoBehaviour
{
    public AudioClip playerHurt; // Stores the player hurt sound
    public AudioClip abilityUse; // Stores the ability use sound
    public AudioClip enemyHurt; // Stores the enemy hurt sound

    // Awake is called at the start of the program
    private void Awake()
    {
        DontDestroyOnLoad(gameObject); // Set this object to not destroy on switching scenes
    }
}
