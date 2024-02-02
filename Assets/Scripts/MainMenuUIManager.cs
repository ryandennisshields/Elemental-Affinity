using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Class for main menu UI management
// This code is manages the UI in the main menu.
public class MainMenuUIManager : MonoBehaviour
{
    // Function for starting the game
    public void StartGame()
    {
        SceneManager.LoadScene("WorldMap"); // Load the "Main Menu" scene
    }

    // Function for exiting the game
    public void ExitGame()
    {
        Application.Quit(); // Close the application
    }
}
