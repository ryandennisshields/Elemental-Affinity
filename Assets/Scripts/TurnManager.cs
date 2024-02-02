using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class for managing turns
// This code controls how turns work, including the order of game objects and limits.
public class TurnManager : MonoBehaviour
{
    public PlayerMovement playerMovement; // Stores the player movement script
    public AbilityManager abilityManager; // Stores the ability manager script

    private GameObject[] enemies; // Stores the enemies
    private GameObject highestMovementPointsEnemy; // Stores the enemy with the highest movement points

    public static int turn ; // Stores the current turn
    private bool turnStarted; // Bool for deciding if the turn has started or not
    
    // Start is called before the first frame update
    void Start()
    {
        highestMovementPointsEnemy = null; // Set the highest movement points enemy to null
        turnStarted = false; // Set turn started to false
        playerMovement.movementPoints = 0; // Set the player's movement points to 0
        turn = 1; // Sets the turn to 1
        enemies = GameObject.FindGameObjectsWithTag("Enemy"); // Sets enemies to objects with the tag "Enemy"
        StartCoroutine(StartTurn()); // Start the Start Turn coroutine
    }

    // Coroutine for the start of a turn
    IEnumerator StartTurn()
    {
        if (!turnStarted)
        { // If the turn has not started,
            turnStarted = true; // Set turn started to true
            foreach (GameObject enemy in enemies)
            { // For each enemy,
                var enemyAI = enemy.GetComponent<EnemyAI>(); // Get the enemy's enemy AI component
                if (highestMovementPointsEnemy == null || enemyAI.movementPoints > highestMovementPointsEnemy.GetComponent<EnemyAI>().movementPoints)
                { // If the highest movement points enemy is null or the enemy's movement points are greater than the current highest movement point enemy's own movement points,
                    highestMovementPointsEnemy = enemy; // Set the highest movement point enemy to the new enemy
                }
            }
            var highestMovementPointsEnemyAI = highestMovementPointsEnemy.GetComponent<EnemyAI>(); // Grab the highest movement point enemy's enemy AI script
            yield return new WaitUntil(() => highestMovementPointsEnemyAI.movementPoints <= 0); // Wait until the movement points are less than or equal to 0
            yield return new WaitForSeconds(2f); // Wait for 2 seconds
            GameObject.Find("UI").GetComponent<LevelUIManager>().turnDetails.text = "PLAYER TURN"; // Find andd set the turn details text to "PLAYER TURN"
            playerMovement.movementPoints = playerMovement.maxMovementPoints; // Set the player's movement points to the maximum movement points
            GameObject[] slots = GameObject.FindGameObjectsWithTag("Ability Slot"); // Get and store slots from objects with the tag "Ability Slot" 
            foreach (var slot in slots)
            { // For each slot in slots,
                slot.GetComponent<AbilitySlot>().DecreaseCooldown(); // Run the Decrease Cooldown function in the abiltiy slots
            }
            abilityManager.abilitiesAllowed = true; // Allow ability manager to use abilities
        }
    }

    // Function for ending a turn
    public void EndTurn()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy"); // Sets enemies to objects with the tag "Enemy"
        foreach (GameObject enemy in enemies)
        { // For each enemy,
            var enemyAI = enemy.GetComponent<EnemyAI>(); // Get the enemy's enemy AI component
            if (highestMovementPointsEnemy == null || enemyAI.movementPoints > highestMovementPointsEnemy.GetComponent<EnemyAI>().movementPoints)
            { // If the highest movement points enemy is null or the enemy's movement points are greater than the current highest movement point enemy's own movement points,
                highestMovementPointsEnemy = enemy; // Set the highest movement point enemy to the new enemy
            }
        }
        if (highestMovementPointsEnemy.GetComponent<EnemyAI>().movementPoints <= 0)
        { // If enemy movememnt points are less than 0,
            turn++; // Add a turn
            turnStarted = false; // Set turn started to false
            GameObject.Find("UI").GetComponent<LevelUIManager>().turnDetails.text = "ENEMY TURN"; // Find andd set the turn details text to "ENEMY TURN"
            playerMovement.movementPoints = 0; // Set the player's movement points to 0
            abilityManager.abilitiesAllowed = false; // Stop the ability manager to from using abilities
            foreach (GameObject enemy in enemies)
            { // For each enemy,
                var enemyAI = enemy.GetComponent<EnemyAI>(); // Get the enemy's enemy AI component
                enemyAI.movementPoints = enemyAI.maxMovementPoints; // Set the enemy's movememnt points to it's max movement points
                enemyAI.TakeTurn(); // Run the enemy AI's Take Turn function
                StartCoroutine(StartTurn()); // Run the Start Turn coroutine
            }
        }
    }
}
