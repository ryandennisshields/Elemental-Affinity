using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class for quake
// This code controls the logic of the Quake ability.
public class Quake : MonoBehaviour
{
    private int damageMin = 5; // Stores the minimum damage
    private int damageMax = 6; // Stores the maximum damage

    // Start is called before the first frame update
    void Start()
    {
        transform.Translate(2, 0, 0); // Move the object forward in front of the player
        if (transform.eulerAngles.z > 90 && transform.eulerAngles.z < 270) // If the angle of the object is greater than 90 and less than 270,
            transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, 0); // Set the scale to face left
        StartCoroutine(QuakeAttack()); // Start the quake attack routine
    }

    // Called whenever a collision is detected
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        { // If the collision is with an enemy,
            collision.gameObject.GetComponent<EnemyAI>().health -= Random.Range(damageMin, damageMax + 1); // Take away the enemy's health by a random value between the minimum damage and maximum damage
            AudioSource.PlayClipAtPoint(GameObject.Find("Sound Manager").GetComponent<SoundManager>().enemyHurt, transform.position, 1); // Play the enemy hurt sound from the sound manager
        }
    }

    // Coroutine for the quake attack
    IEnumerator QuakeAttack()
    {
        yield return new WaitForSeconds(0.6f); // Wait for 0.6 seconds
        Destroy(this.gameObject); // Destroy this game object
    }
}
