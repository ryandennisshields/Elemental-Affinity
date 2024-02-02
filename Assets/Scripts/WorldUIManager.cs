using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

// Class for the world UI management
// This code manages the UI in the world map.
public class WorldUIManager : MonoBehaviour
{
    public GameObject mainScreen; // Stores the main screen
    public GameObject shopScreen; // Stores the shop screen
    public Tilemap tilemap; // Stores the tilemap

    public TextMeshProUGUI levelNumberText; // Stores the level number text
    public TextMeshProUGUI levelCompletionText;
    public TextMeshProUGUI levelScoreText; // Stores the level score text

    private int selectedWorld; // Stores the selected world
    private int selectedLevel; // Stores the selected level
    private string selectedWorldLevel; // Stores the selected world and level

    public TileBase level; // Stores the level tile
    public TileBase levelWon; // Stores the level won tile
    public TileBase levelComplete; // Stores the level complete tile

    private Vector3Int selectedLevelCompletion; // Stores the completion of the selected level
    private float selectedLevelScore; // Stores the score of the selected level

    // Start is called before the first frame update
    private void Start()
    {
        selectedWorld = 1; // Set selected world to 1
        selectedLevel = 1; // Set selected level to 1
        selectedWorldLevel = "1-1"; // Set the selected world level to 1-1
        selectedLevelScore = PlayerPrefs.GetFloat(selectedWorld + "-" + selectedLevel); // Set the selected level score to the stored score of the world and selected level 
        levelScoreText.text = "SCORE " + selectedLevelScore; // Set the level score text to the selected level score
        selectedLevelCompletion = tilemap.WorldToCell(GameObject.Find("Player").transform.position); // Set the selected level completion tile to the tile under the player
        if (selectedLevelScore >= 7500)
        { // If score is greater than or equal to 7500,
            tilemap.SetTile(selectedLevelCompletion, levelComplete); // Set the tile under the player to the level complete tile
            levelCompletionText.text = "COMPLETE"; // Set the level completion text to "complete"
        }
        else if (selectedLevelScore > 0 && selectedLevelScore < 7500)
        { // If score is greater than 0 and less than 7500,
            tilemap.SetTile(selectedLevelCompletion, levelWon); // Set the tile under the player to the level won tile
            levelCompletionText.text = "WON"; // Set the level completion text to "won"
        }
        else
        { // If score is not greater than 0 or less than 7500, 
            tilemap.SetTile(selectedLevelCompletion, level); // Set the tile under the player to the level tile
            levelCompletionText.text = "UNCLEARED"; // Set the level completion text to "uncleared"
        }
    }

    // Function to go to the main menu
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu"); // Load the "Main Menu" scene
    }
    
    // Function for the shop
    public void Shop()
    {
        mainScreen.SetActive(false); // Disable the main screen
        shopScreen.SetActive(true); // Enable the shop screen
        GameObject.Find("Ability Loader").GetComponent<AbilityLoader>().InitialiseSlots(); // Initialise the ability slots
    }

    // Function for going back to the main screen
    public void Back()
    {
        shopScreen.SetActive(false); // Disable the shop screen
        mainScreen.SetActive(true); // Enable the main screen
    }

    // Function for navigating between levels
    public void LevelNavigate(int direction)
    {
        int worldNumber = selectedWorld; // Create and store the selected world
        int cappedLevel = selectedLevel += direction; // Create and store the selected level plus the direction
        if (cappedLevel > 0 && cappedLevel <= 10)
        { // If the level is within the capped levels,
            int levelNumber = cappedLevel; // Save the selected level
            var nextLevelScore = PlayerPrefs.GetFloat(worldNumber + "-" + levelNumber); // Grab the next level score from the saved scores
            if (selectedLevelScore != 0 || nextLevelScore != 0)
            { // If the selected level score is not equal to 0 or the next level score is not equal to 0,
                selectedWorldLevel = worldNumber + "-" + levelNumber; // Change the selected world level to match the world and level
                levelNumberText.text = "LEVEL " + levelNumber; // Set the level number text to display the new level
                selectedLevelScore = PlayerPrefs.GetFloat(selectedWorld + "-" + selectedLevel); // Set the selected level score to the stored score of the world and selected level
                levelScoreText.text = "SCORE " + PlayerPrefs.GetFloat(selectedWorldLevel); // Set the level score text to the selected level score
                if (selectedLevelScore >= 7500)
                { // If score is greater than or equal to 7500,
                    tilemap.SetTile(selectedLevelCompletion, levelComplete); // Set the tile under the player to the level complete tile
                    levelCompletionText.text = "COMPLETE"; // Set the level completion text to "complete"
                }
                else if (selectedLevelScore > 0 && selectedLevelScore < 7500)
                { // If score is greater than 0 and less than 7500,
                    tilemap.SetTile(selectedLevelCompletion, levelWon); // Set the tile under the player to the level won tile
                    levelCompletionText.text = "WON"; // Set the level completion text to "won"
                }
                else
                { // If score is not greater than 0 or less than 7500, 
                    tilemap.SetTile(selectedLevelCompletion, level); // Set the tile under the player to the level tile
                    levelCompletionText.text = "UNCLEARED"; // Set the level completion text to "uncleared"
                }
            }
            else if (nextLevelScore == 0 && selectedLevelScore == 0)
            { // If the next level score is 0 and the selected level score is 0,
                worldNumber = selectedWorld; // Keep the world number the same
                levelNumber = selectedLevel -= direction; // Set the level number to the selected level take away the direction
            }
        }
        else
        { // If the level is not within the capped levels,
            worldNumber = selectedWorld; // Keep the world number the same
            cappedLevel = selectedLevel -= direction; // Set the level number to the selected level take away the direction
        }
    }

    // Function for loading a level
    public void LoadLevel()
    {
        LevelLoader.level = selectedWorldLevel; // Set the level loader's level to the selected world level
        SceneManager.LoadScene("Level"); // Load the level scene
    }
}
