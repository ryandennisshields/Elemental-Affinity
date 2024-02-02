using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class for player health
// This code manages the player's health (or hit points).
public class PlayerHealth : MonoBehaviour
{
    public static int hitPoints; // Stores the hit points

    public AudioClip hitSound; // Sound for getting hit

    // Start is called before the first frame update
    void Start()
    {
        hitPoints = 20; // Set the hit points to 20
    }
}
