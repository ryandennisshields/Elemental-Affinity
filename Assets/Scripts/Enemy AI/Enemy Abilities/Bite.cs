using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class for bite
// This code controls the logic of the Bite enemy ability.
public class Bite : MonoBehaviour
{
    private int damageMin = 1; // Stores the minimum damage
    private int damageMax = 2; // Stores the maximum damage

    // Start is called before the first frame update
    void Start()
    {
        PlayerHealth.hitPoints -= Random.Range(damageMin, damageMax + 1); // Take away hit points from the player by a random value between the damage minimum and maximum
        AudioSource.PlayClipAtPoint(GameObject.Find("Sound Manager").GetComponent<SoundManager>().playerHurt, transform.position, 1); // Play the player hurt sound from the sound manager
        Destroy(this.gameObject); // Destory this game object
    }
}
