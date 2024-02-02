using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class for fire bolt
// This code controls the logic of the Fire Bolt ability.
public class FireBolt : MonoBehaviour
{
    private int damageMin = 1; // Stores the minimum damage
    private int damageMax = 2; // Stores the maximum damage

    // Start is called before the first frame update
    private void Start()
    {
        if (transform.eulerAngles.z > 90 && transform.eulerAngles.z < 270) // If the angle of the object is greater than 90 and less than 270,
            transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, 0); // Set the scale to face left
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(8 * Time.deltaTime, 0, 0); // Move the object
    }

    // Called whenever a collision is detected
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        { // If the collision was not with the player,
            Destroy(this.gameObject); // Destroy this object
            if (collision.gameObject.CompareTag("Enemy"))
            { // If the collision is with an enemy,
                collision.gameObject.GetComponent<EnemyAI>().health -= Random.Range(damageMin, damageMax + 1); // Take away the enemy's health by a random value between the minimum damage and maximum damage
                AudioSource.PlayClipAtPoint(GameObject.Find("Sound Manager").GetComponent<SoundManager>().enemyHurt, transform.position, 1); // Play the enemy hurt sound from the sound manager
            }
        }
    }
}
