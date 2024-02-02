using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

// Class for enemy AI
// This code acts as a parent for any enemy, as it controls and stores the basic logic and values of an enemy.
public class EnemyAI : MonoBehaviour
{
    [Header("General")]
    public Tilemap tileMap; // Stores the tile map
    public GameObject player; // Stores the player
    public int movementPoints; // Stores the movememnt points
    public Vector3 centerStartTile; // Stores the center of the start tile
    public Slider healthBar; // Stores the health bar
    [Header("Enemy Specific")]
    public float health; // Stores the health
    public int maxMovementPoints; // Stores the maximum movement points
    public MonoBehaviour enemyScript; // Stores the enemy script

    // Start is called before the first frame update
    void Start()
    {
        movementPoints = 1; // Set the movement points to 1 (Stops other code from breaking)
        tileMap = GameObject.Find("Tilemap").GetComponent<Tilemap>(); // Get and set the tilemap to the Tilemap object's Tilemap component 
        player = GameObject.Find("Player"); // Set the player variable to the player object
        TakeTurn(); // Run the take turn function
    }

    // Late Update is called once per frame after Update
    void LateUpdate()
    {
        healthBar.value = health; // Updates the health bar's value to the health
        if (health <= 0)
        { // If health is less than or equal to 0,
            Destroy(this.gameObject); // Destroy this object
        }
    }

    // Function for starting the enemy's turn
    public void TakeTurn()
    {
        enemyScript.StartCoroutine("TurnActions"); // Start the turn actions coroutine in the enemy script
    }

    // Called whenever a collision is detected
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        { // If the collision is with an enemy,
            transform.position = centerStartTile; // Set the object position to the center of the start tile
        }
    }
}
