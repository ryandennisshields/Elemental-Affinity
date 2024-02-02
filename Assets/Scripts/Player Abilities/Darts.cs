using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class for darts
// This code controls the logic of the Darts ability
public class Darts : MonoBehaviour
{
    private int damageMin = 1; // Stores the minimum damage
    private int damageMax = 2; // Stores the maximum damage
    private int attackCount = 6; // Stores the amount of attacks

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DartsAttack()); // Start the darts attack coroutine
    }

    // Coroutine for the darts attack
    IEnumerator DartsAttack()
    {
        var enemies = GameObject.FindGameObjectsWithTag("Enemy"); // Get all the game objects with the tag "Enemy"
        var randomEnemy = Random.Range(0, enemies.Length); // Get a random enemy from a random range between 0 and the enemies alive
        for (int i = 0; i < attackCount; i++)
        { // For the attack count,
            if (enemies[randomEnemy] != null)
            { // If the random enemy exists,
                enemies[randomEnemy].GetComponent<EnemyAI>().health -= Random.Range(damageMin, damageMax + 1); // Take away the enemy's health by a random value between the minimum damage and maximum damage
                AudioSource.PlayClipAtPoint(GameObject.Find("Sound Manager").GetComponent<SoundManager>().enemyHurt, enemies[randomEnemy].transform.position, 1); // Play the enemy hurt sound from the sound manager at the random enemy
            }
            randomEnemy = Random.Range(0, enemies.Length); // Get a random enemy from a random range between 0 and the enemies alive
            yield return new WaitForSeconds(0.4f); // Wait 0.4 seconds
        }
    }
}
