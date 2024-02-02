using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class for snipe
// This code controls the logic of the Snipe ability.
public class Snipe : MonoBehaviour
{
    private int damage = 2; // Stores the damage

    // Start is called before the first frame update
    private void Start()
    {
        if (transform.eulerAngles.z > 90 && transform.eulerAngles.z < 270) // If the angle of the object is greater than 90 and less than 270,
            transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, 0); // Set the scale to face left
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(10 * Time.deltaTime, 0, 0); // Move the object
    }

    // Called whenever a collision is detected
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        { // If the collision was not with the player,
            if (collision.gameObject.CompareTag("Enemy"))
            { // If the collision is with an enemy,
                collision.gameObject.GetComponent<EnemyAI>().health -= damage; // Take away the enemy's health by the damage
                AudioSource.PlayClipAtPoint(GameObject.Find("Sound Manager").GetComponent<SoundManager>().enemyHurt, transform.position, 1); // Play the enemy hurt sound from the sound manager
            }
            else
            { // If the collision is not with an enemy,
                Destroy(this.gameObject); // Destroy this object
            }
        }
    }
}
