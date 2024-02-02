using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

// Class for level UI manager
// This code manages the UI in levels.
public class LevelUIManager : MonoBehaviour
{
    public GameObject HUD; // Stores the HUD
    public GameObject levelWinScreen; // Stores the win screen

    public Slider healthValue; // Stores the health value
    public TextMeshProUGUI movementPoints; // Stores the movement points
    public TextMeshProUGUI turnDetails; // Stores the turn details
    public TextMeshProUGUI turnNumber; // Stores the turn number
    public TextMeshProUGUI moveOruseText; // Stores the move/use text

    private bool execute; // Stores a bool for executing a part of code once

    // Start is called before the first frame update
    void Start()
    {
        execute = true; // Set execute to true
    }

    // Update is called once per frame
    void Update()
    {
        var healthChange = PlayerHealth.hitPoints; // Get and store the player's hit points from their health
        healthValue.value = healthChange; // Change the health value to the new value
        movementPoints.text = "" + GameObject.Find("Player").GetComponent<PlayerMovement>().movementPoints; // Change the movement point text to read the player's movement points
        turnNumber.text = "" + TurnManager.turn; // Set the turn number to the turn manager's turn
        if (GameObject.Find("Ability Manager").GetComponent<AbilityManager>().abilitySelected == true)
        { // If an ability is selected,
            moveOruseText.text = "USE"; // Change the move or use text to "USE"
        }
        else
        { // If an ability is not selected,
            moveOruseText.text = "MOVE"; // Change the move or use text to "MOVE"
        }
        var enemiesLeft = GameObject.FindGameObjectsWithTag("Enemy"); // Find and store game objects with the tag "Enemy"
        if (enemiesLeft.Length == 0 || PlayerHealth.hitPoints <= 0)
        { // If there is no enemies left or if the player's hit points are less than or equal to 0,
            LevelDone(); // Run the level done function
        }
    }

    // Function for when a level is complete
    void LevelDone()
    {
        if (execute)
        { // If the code is to be executed,
            HUD.SetActive(false); // Disable the HUD
            levelWinScreen.SetActive(true); // Enable the win screen
            execute = false; // Set execute to false
        }
    }

    // Function for restarting
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
    }

    // Function for going to the world map
    public void WorldMap()
    {
        SceneManager.LoadScene("WorldMap"); // Load the scene "World Map"
    }
}
