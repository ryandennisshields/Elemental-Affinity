using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class for heal
// This code controls the logic of the Heal ability.
public class Heal : MonoBehaviour
{
    private int healValue = 4; // Stores the heal value

    // Start is called before the first frame update
    void Start()
    {
        PlayerHealth.hitPoints += healValue; // Add hit points to the player by the heal value
        Destroy(this.gameObject); // Destroy this game object
    }
}
