using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Class for whirlwind
// This code controls the logic of the Whirlwind ability.
public class Whirlwind : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] slots = GameObject.FindGameObjectsWithTag("Ability Slot"); // Get and store slots from objects with the tag "Ability Slot" 
        foreach (var slot in slots)
        { // For each slot in slots,
            var slotID = slot.GetComponent<AbilitySlot>().slotID; // Get the slot slot ID
            GameObject.Find("Player").GetComponent<PlayerMovement>().movementPoints = GameObject.Find("Player").GetComponent<PlayerMovement>().maxMovementPoints; // Set the player movement points to the max movement points
            if (slotID != 5)
            { // If the slot id is not 5,
                for (int i = 0; i < 10; i++)
                { // For 10 times,
                    slot.GetComponent<AbilitySlot>().DecreaseCooldown(); // Run the Decrease Cooldown function in the ability slots
                }
            }
            if (slotID == 5)
            { // If the slot id is 5,
                slot.GetComponent<Button>().interactable = false; // Set the slot button component to not be interactable
                slot.GetComponentInChildren<TextMeshProUGUI>().gameObject.SetActive(false); // Set the text in the object's children to be inactive
            }
        }
    }
}
