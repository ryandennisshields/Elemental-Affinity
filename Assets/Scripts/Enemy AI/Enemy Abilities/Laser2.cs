using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class for laser 2
// This code controls the logic of the Laser 2 enemy ability.
public class Laser2 : MonoBehaviour
{
    private int damageMin = 2; // Stores the minimum damage
    private int damageMax = 4; // Stores the maximum damage

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 20 * Time.deltaTime, 0); // Move the object
    }

    // Called whenever a collision is detected
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        { // If the collision is with the player,
            PlayerHealth.hitPoints -= Random.Range(damageMin, damageMax + 1); // Take away hit points from the player by a random value between the damage minimum and maximum
            AudioSource.PlayClipAtPoint(GameObject.Find("Sound Manager").GetComponent<SoundManager>().playerHurt, transform.position, 1); // Play the player hurt sound from the sound manager
        }
        Destroy(this.gameObject); // Destroy this object
    }
}
