using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class for the footsoldier enemy
// This code manages the logic of the footsoldier enemy.
public class Footsoldier : MonoBehaviour
{
    private EnemyAI enemyAI; // Store the enemy AI script

    private Vector2 target; // Store the target
    private Object ability; // Stores this enemy's ability

    // Start is called before the first frame update
    void Start()
    {
        enemyAI = GetComponent<EnemyAI>(); // Set the enemy AI script
        enemyAI.health = 6; // Set the health to 6
        enemyAI.healthBar.maxValue = enemyAI.health; // Set the health bar's max value to the health
        enemyAI.maxMovementPoints = 2; // Set the max movement points to 2
        enemyAI.movementPoints = enemyAI.maxMovementPoints; // Set the movement points to the max movement points
        target = GameObject.Find("Player").transform.position; // Set the target to the player's position
        ability = Resources.Load("Enemy Abilities/Laser1"); // Instantiate the "Laser1" object and set it as the ability
    }


    // Coroutine for an enemy's turn
    public IEnumerator TurnActions()
    {
        target = GameObject.Find("Player").transform.position; // Set the target to the player's position
        Vector2 moveRotation = new(transform.position.x, target.y); // Set the move rotation to the target's y position
        yield return new WaitForSeconds(0.4f); // Wait for 0.4 seconds
        Collider2D hitBox = transform.GetChild(0).GetComponent<Collider2D>(); // Create and set the hitbox to the first child component's Collider
        if (hitBox.IsTouching(enemyAI.player.GetComponent<Collider2D>()))
        { // If the hit box is touching the player,
            Instantiate(ability, transform.position, Quaternion.LookRotation(Vector3.forward, enemyAI.player.transform.position - transform.position)); // Instantiate the ability on the player object
            enemyAI.movementPoints = 0; // Set movement points to 0
        }
        else
        { // If the hit box is not touching the player,
            var startTile = enemyAI.tileMap.WorldToCell(transform.position); // Create and set the start tile to the tile at the current position of this game object
            enemyAI.centerStartTile = enemyAI.tileMap.GetCellCenterWorld(startTile); // Get and set the center of the starting tile
            var movement = Vector2.MoveTowards(enemyAI.centerStartTile, moveRotation, 0.535f); // Get and set the next tile over from the center of the starting tile towards the move direction in a 0.535 units line
            var tilePosition = enemyAI.tileMap.WorldToCell(movement); // Set the tile position to the tile at the movement position
            var tileBase = enemyAI.tileMap.GetTile(tilePosition); // Create and set the tile base to the tile position
            if (tileBase != null)
            { // If the tile base is not null (If the tile exists),
                if (tileBase.name == "NormalTile")
                { // If the tile is named "Normal Tile",
                    var tileCentre = enemyAI.tileMap.GetCellCenterWorld(tilePosition); // Create and set the tile centre to the centre of the tile
                    if (target.x > transform.position.x) // If the target x is greater than the enemy's current x position,
                    {
                        transform.localScale = new(1.5f, 1.5f, 1); // Set the enemy's local scale to face right
                        enemyAI.healthBar.transform.localScale = new(1f, 1f, 1); // Keep the health bar the same
                    }
                    else if (target.x < transform.position.x) // If the target x is less than the enemy's current x position,
                    {
                        transform.localScale = new(-1.5f, 1.5f, 1); // Set the enemy's local scale to face left
                        enemyAI.healthBar.transform.localScale = new(-1f, 1f, 1); // Keep the health bar the same
                    }
                    transform.position = tileCentre; // Set this game object's position to the tile centre
                }
            }
            enemyAI.movementPoints--; // Remove 1 from the movement points
        }
        yield return new WaitForSeconds(0.4f); // Wait for 0.4 seconds
        if (enemyAI.movementPoints > 0)
        { // If movememnt points are greater than 0,
            enemyAI.TakeTurn(); // Run the Take Turn function
        }
    }
}
