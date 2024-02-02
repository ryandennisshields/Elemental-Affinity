using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Class for rock armour
// This code controls the logic of the Rock Armour ability.
public class RockArmour : MonoBehaviour
{
    private int tempHealth; // Stores the temporary health
    private int turnsActive; // Stores the amount of turns active

    private bool execute; // Stores a bool for executing some code once

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] slots = GameObject.FindGameObjectsWithTag("Ability Slot"); // Get and store slots from objects with the tag "Ability Slot" 
        foreach (var slot in slots)
        { // For each slot in slots,
            var slotID = slot.GetComponent<AbilitySlot>().slotID; // Get the slot slot ID
            if (slotID == 5)
            { // If slot ID is 5,
                slot.GetComponent<Button>().interactable = false; // Set the slot button component to not be interactable
                slot.GetComponentInChildren<TextMeshProUGUI>().gameObject.SetActive(false); // Set the text in the object's children to be inactive
            }
        }
        tempHealth = PlayerHealth.hitPoints; // Set the temporary health to the player's current health
        turnsActive = TurnManager.turn + 3; // Set the turns active to the current turn plus 3
        execute = true; // Set execute to true
        PlayerHealth.hitPoints = 999; // Set the player's health to 999
    }

    // Update is called once per frame
    private void Update()
    {
        if (turnsActive == TurnManager.turn && execute == true)
        { // If turns active equal the current turn and execute is true,
            PlayerHealth.hitPoints = tempHealth; // Set the player's health to the temporary health
            execute = false; // Set execute to false
            Destroy(this.gameObject); // Destroy this object
        }
        var player = GameObject.Find("Player"); // Store the player
        transform.position = player.transform.position; // Set this object's position to the player's position
        transform.rotation = player.transform.rotation; // Set this object's rotation to the player's rotation
        transform.localScale = player.transform.localScale; // Set this object's scale to the player's scale
    }
}
