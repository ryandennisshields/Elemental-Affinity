using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

// Class for managing abilities
// This code is what allows the player to use abilities in levels.
public class AbilityManager : MonoBehaviour
{
    private Object ability; // Stores the ability object
    private GameObject slot; // Stores the slot object
    private GameObject player; // Stores the player object

    public bool abilitiesAllowed = false; // Stores a bool deciding if abilities are allowed
    public bool abilitySelected = false; // Stores a bool deciding if an ability is selected or not, and sets it to false
    private int tempMovementpoints; // Temporarily stores the player's movement points


    // Start is called before the first frame update
    void Start()
    {
        tempMovementpoints = 0; // Set the temporary movement points to 0
        StartCoroutine(AbilityLoader.AbilityLoading()); // Start the ability loading coroutine in ability slot management
        player = GameObject.Find("Player"); // Set player to the object named "Player"
    }

    // Function for when an ability is selected
    public void AbilityPreuse(string abilityHere, GameObject slotHere)
    {
        if (abilitiesAllowed)
        { // If abilities are allowed,
            ability = Resources.Load("Player Abilities/" + abilityHere); // Sets the ability to an ability stored in resources, the ability depending on what ability is loaded into the selected slot
            slot = slotHere; // Sets the slot to the slot where the ability was used from
            abilitySelected = true; // Set ability selected to true
            if (player.GetComponent<PlayerMovement>().movementPoints > 0)
            { // If the player has movement points,
                tempMovementpoints = player.GetComponent<PlayerMovement>().movementPoints; // Sets the temporary movement points to the player's current movement points
            }
            player.GetComponent<PlayerMovement>().movementPoints = 0; // Gets the player's movement points and sets it to 0
        }
    }

    // Function for using abilities
    public void AbilityUse(float abilityDirection)
    {
        if (abilitySelected)
        { // If an ability is selected,
            Instantiate(ability, player.transform.position, Quaternion.Euler(0, 0, abilityDirection)); // Instantiate the abiity at the player's position, with the rotation depending on the specific movement button pressed
            AudioSource.PlayClipAtPoint(GameObject.Find("Sound Manager").GetComponent<SoundManager>().abilityUse, player.transform.position, 1); // Play the ability use sound from the sound manager at the player
            abilitySelected = false; // Set ability selected to false
            player.GetComponent<PlayerMovement>().movementPoints = tempMovementpoints; // Set the player's movement points to the temporary movement points
            slot.GetComponent<AbilitySlot>().ResetCooldown(); // Start the ability reset cooldown script in the ability slot
        }
    }

    // Function for cancelling abilities
    public void AbilityCancel()
    {
        if (abilitySelected)
        { // If an ability is selected,
            abilitySelected = false; // Set ability selected to false
            player.GetComponent<PlayerMovement>().movementPoints = tempMovementpoints; // Set the player's movement points to the temporary movement points
        }
    }
}
