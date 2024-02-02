using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class for fire ball
// This code controls the logic of the Fire Ball ability.
public class Fireball : MonoBehaviour
{
    private int damageMin = 3; // Stores the minimum damage
    private int damageMax = 4; // Stores the maximum damage

    public Sprite explosion; // Stores the explosion sprite

    // Start is called before the first frame update
    private void Start()
    {
        if (transform.eulerAngles.z > 90 && transform.eulerAngles.z < 270) // If the angle of the object is greater than 90 and less than 270,
            transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, 0); // Set the scale to face left
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(5 * Time.deltaTime, 0, 0); // Move the object
    }

    // Called whenever a collision is detected
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        { // If the collision was not with the player,
            StartCoroutine(Explosion()); // Start the explosion coroutine
            if (collision.gameObject.CompareTag("Enemy"))
            { // If the collision is with an enemy,
                collision.gameObject.GetComponent<EnemyAI>().health -= Random.Range(damageMin, damageMax + 1); // Take away the enemy's health by a random value between the minimum damage and maximum damage
                AudioSource.PlayClipAtPoint(GameObject.Find("Sound Manager").GetComponent<SoundManager>().enemyHurt, transform.position, 1); // Play the enemy hurt sound from the sound manager
            }
        }
    }

    // Function for the explosion
    IEnumerator Explosion()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = explosion; // Set the sprite to the explosion sprite
        transform.localScale = new(5, 3, 1); // Set the scale to be bigger (reach the tiles around the object)
        yield return new WaitForSeconds(0.1f); // Wait for 0.1 seconds
        Destroy(this.gameObject); // Destroy this object
    }
}
