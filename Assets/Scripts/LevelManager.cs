using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Code for level management
// This code loads a level's information, mainly the player's position, enemies and enemy positions. This code is also set to always be first in the execution order. 
public class LevelManager : MonoBehaviour
{

    // UPDATE WITH SPECIFIC ENEMIES
    public GameObject dog; // Stores the dog enemy
    public GameObject footsoldier; // Stores the footsoldier enemy
    public GameObject commander; // Stores the commander enemy
    public GameObject hulk; // Stores the hulk enemy
    public GameObject boss; // Stores the boss enemy

    // Awake is called at the start of the program
    void Awake()
    {
        if (LevelLoader.level == "1-1")
        { // If the level is 1-1,
            GameObject.Find("Player").transform.position = new Vector2(-5.5f, 1.75f); // Find the player object and set the position to the starting position of 1-1
            // Instantiate the enemies for 1-1
            Instantiate(dog, new Vector2(5.5f, 1.75f), new Quaternion());
        }
        else if (LevelLoader.level == "1-2")
        { // If the level is 1-2,
            GameObject.Find("Player").transform.position = new Vector2(-5.5f, 1.75f); // Find the player object and set the position to the starting position of 1-2
            // Instantiate the enemies for 1-2
            Instantiate(dog, new Vector2(5.5f, 2.875f), new Quaternion());
            Instantiate(dog, new Vector2(5.5f, 1.75f), new Quaternion());
            Instantiate(dog, new Vector2(5.5f, 0.625f), new Quaternion());
        }
        else if (LevelLoader.level == "1-3")
        { // If the level is 1-3,
            GameObject.Find("Player").transform.position = new Vector2(-5.5f, 1.75f); // Find the player object and set the position to the starting position of 1-3
            // Instantiate the enemies for 1-3
            Instantiate(footsoldier, new Vector2(4f, 4.5f), new Quaternion());
            Instantiate(footsoldier, new Vector2(6f, -1.25f), new Quaternion());
        }
        else if (LevelLoader.level == "1-4")
        { // If the level is 1-4,
            GameObject.Find("Player").transform.position = new Vector2(0f, 1f); // Find the player object and set the position to the starting position of 1-4
            // Instantiate the enemies for 1-4
            Instantiate(dog, new Vector2(-7f, 1.15f), new Quaternion());
            Instantiate(dog, new Vector2(7f, 1.15f), new Quaternion());
            Instantiate(footsoldier, new Vector2(-6f, 3.35f), new Quaternion());
            Instantiate(footsoldier, new Vector2(6f, 3.35f), new Quaternion());
        }
        else if (LevelLoader.level == "1-5")
        { // If the level is 1-5,
            GameObject.Find("Player").transform.position = new Vector2(-5.5f, 1.75f); // Find the player object and set the position to the starting position of 1-5
            // Instantiate the enemies for 1-5
            Instantiate(commander, new Vector2(6f, 0f), new Quaternion());
            Instantiate(dog, new Vector2(4f, 3.35f), new Quaternion());
            Instantiate(dog, new Vector2(4f, 0f), new Quaternion());
        }
        else if (LevelLoader.level == "1-6")
        { // If the level is 1-6,
            GameObject.Find("Player").transform.position = new Vector2(0f, 0f); // Find the player object and set the position to the starting position of 1-6
            // Instantiate the enemies for 1-6
            Instantiate(commander, new Vector2(0f, 3.35f), new Quaternion());
            Instantiate(dog, new Vector2(4f, 3.35f), new Quaternion());
            Instantiate(dog, new Vector2(-4f, 3.35f), new Quaternion());
        }
        else if (LevelLoader.level == "1-7")
        { // If the level is 1-7,
            GameObject.Find("Player").transform.position = new Vector2(-1.5f, 1.75f); // Find the player object and set the position to the starting position of 1-7
            // Instantiate the enemies for 1-7
            Instantiate(hulk, new Vector2(1.5f, 1.75f), new Quaternion());
        }
        else if (LevelLoader.level == "1-8")
        { // If the level is 1-8,
            GameObject.Find("Player").transform.position = new Vector2(-1.5f, 1.75f); // Find the player object and set the position to the starting position of 1-8
            // Instantiate the enemies for 1-8
            Instantiate(hulk, new Vector2(1.5f, 1.75f), new Quaternion());
            Instantiate(dog, new Vector2(5.5f, 2.875f), new Quaternion());
            Instantiate(dog, new Vector2(5.5f, 1.75f), new Quaternion());
            Instantiate(dog, new Vector2(5.5f, 0.625f), new Quaternion());
        }
        else if (LevelLoader.level == "1-9")
        { // If the level is 1-9,
            GameObject.Find("Player").transform.position = new Vector2(0.5f, 1.75f); // Find the player object and set the position to the starting position of 1-9
            // Instantiate the enemies for 1-9
            Instantiate(hulk, new Vector2(-3.5f, 1.75f), new Quaternion());
            Instantiate(commander, new Vector2(-5.5f, 3.35f), new Quaternion());
            Instantiate(commander, new Vector2(-5.5f, 0f), new Quaternion());
            Instantiate(dog, new Vector2(5.5f, 2.875f), new Quaternion());
            Instantiate(dog, new Vector2(5.5f, 0.625f), new Quaternion());
        }
        else if (LevelLoader.level == "1-10")
        { // If the level is 1-10,
            GameObject.Find("Player").transform.position = new Vector2(-5.5f, 1.75f); // Find the player object and set the position to the starting position of 1-10
            // Instantiate the enemies for 1-10
            Instantiate(hulk, new Vector2(4.5f, 1.75f), new Quaternion());
            Instantiate(footsoldier, new Vector2(1.5f, 3.35f), new Quaternion());
            Instantiate(footsoldier, new Vector2(1.5f, 0f), new Quaternion());
            Instantiate(commander, new Vector2(-5.5f, 3.35f), new Quaternion());
            Instantiate(boss, new Vector2(5.5f, 1.75f), new Quaternion());
        }
    }
}
