using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Class for score management
// This code manages the score the player earns in a level, and displays the appropiate amount of "stars" at the end of the level dependant on score.
public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Stores the score text
    public Image star1; // Stores the 1st star image
    public Image star2; // Stores the 2nd star image
    public Image star3; // Stores the 3rd star image

    private float score; // Stores the score
    private float healthMultiplier; // Stores the health multiplier
    private float turnMultiplier; // Stores the turn multiplier

    private bool execute; // Stores a bool for executing some code once
    
    // Start is called before the first frame update
    void Start()
    {
        healthMultiplier = 1; // Sets the health multiplier to 1
        turnMultiplier = 1; // Sets the turn multiplier to 1
        score = 10000; // Sets the score to 10,000
        execute = true; // Set execute to true
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy"); // Find and store game objects with the tag "Enemy"
        var health = PlayerHealth.hitPoints; // Create and set health to the player's hit points
        var turns = TurnManager.turn; // Create and set turns to the turn manager's turns
        if (health <= 18 && health >= 14)
        { // If health is less than 18 and greater than 14,
            healthMultiplier = 0.8f; // Set the health multiplier to 0.8
        }
        else if (health <= 14 && health >= 10)
        { // If health is less than 14 and greater than 10,
            healthMultiplier = 0.6f; // Set the health multiplier to 0.6
        }
        else if (health <= 10 && health >= 6)
        { // If health is less than 10 and greater than 6,
            healthMultiplier = 0.4f; // Set the health multiplier to 0.4
        }
        else if (health <= 6 && health > 0)
        { // If health is less than 6 and greater than 0,
            healthMultiplier = 0.2f; // Set the health multiplier to 0.2
        }
        else if (health <= 0)
        { // If health is less than 0,
            healthMultiplier = 0f; // Set the health multiplier to 0.8
        }

        if (turns >= 5 && turns <= 6)
        { // If turns is greater than 5 and less than 6,
            turnMultiplier = 0.8f; // Set the turn multiplier to 0.8
        }
        else if (turns >= 6 && turns <= 7)
        { // If turns is greater than 6 and less than 7,
            turnMultiplier = 0.6f; // Set the turn multiplier to 0.6
        }
        else if (turns >= 7 && turns <= 8)
        { // If turns is greater than 7 and less than 8,
            turnMultiplier = 0.4f; // Set the turn multiplier to 0.4
        }
        else if (turns >= 8 && turns < 9)
        { // If turns is greater than 8 and less than 9,
            turnMultiplier = 0.2f; // Set the turn multiplier to 0.2
        }
        else if (turns >= 9)
        { // If turns is greater than 9,
            turnMultiplier = 0f; // Set the turn multiplier to 0
        }

        if (enemies.Length == 0)
        { // If there are no enemies left,
            TallyScore(); // Run the tally score function
        }
    }

    // Function for tallying score
    void TallyScore()
    {
        if (execute)
        { // If execute is true,
            Debug.Log(healthMultiplier);
            Debug.Log(turnMultiplier);
            score *= (healthMultiplier + turnMultiplier) / 2; // Calculate the score by multiplying it by the health multiplier plus the turn multipler, divided by 2
            scoreText.text = "SCORE: " + score; // Set the score text to the calculated score
            if (score >= 7500)
            { // If score is greater than or equal to 7500,
                star1.gameObject.SetActive(false); // Show the first star
                star2.gameObject.SetActive(false); // Show the second star
                star3.gameObject.SetActive(false); // Show the third star
            }
            else if (score >= 5000 && score < 7500)
            { // If score is greater than or equal to 5000 and less than 7500,
                star1.gameObject.SetActive(false); // Show the first star
                star2.gameObject.SetActive(false); // Show the second star
            }
            else if (score >= 2500 && score < 5000)
            { // If score is greater than or equal to 2500 and less than 5000,
                star1.gameObject.SetActive(false); // Show the first star
            }
            var currentScore = PlayerPrefs.GetFloat(LevelLoader.level); // Set the current score as the saved score for this level
            if (score > currentScore)
            { // If the new score is greater than the current score,
                PlayerPrefs.SetFloat(LevelLoader.level, score); // Save the new score
            }
            execute = false; // Set execute to false
        }
    }
}
