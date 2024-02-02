using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

// Class for ability slots
// This code manages information of what abilities are stored in the ability slots.
public class AbilitySlot : MonoBehaviour
{
    private string thisAbility; // Stores the ability stored on a slot

    private Sprite abilityIcon; // Stores the ability icon

    private int abilityCooldown; // Stores the ability cooldown
    private int maxAbilityCooldown; // Stores the maximum value of the cooldown

    public int slotID; // Stores the slot ID
    private Image iconImage; // Stores the icon image
    private TextMeshProUGUI cooldownText; // Stores the cooldown text

    // Start is called before the first frame update
    private void Start()
    {
        //normalSlots = 1; // Set normal slots to 1
        Image[] images = gameObject.GetComponentsInChildren<Image>(); // Gets images from components in children and stores them in an array
        foreach (Image image in images)
        { // For each image that is in the images array,
            if (image.gameObject.transform.parent != null)
            { // If the image is not the image from the parent object,
                iconImage = image; // Set icon image to image
            }
        }
        iconImage.gameObject.SetActive(false); // Disable the icon image
        cooldownText = gameObject.GetComponentInChildren<TextMeshProUGUI>(); // Set the cooldown text to the text in children
        cooldownText.gameObject.SetActive(false); // Disable the cooldown text
    }

    // Function for equipping abilities
    public void AbilityEquipping(string slotType)
    {
        var otherAbility = GameObject.FindGameObjectWithTag("Ability"); // Find a game object with the tag "Ability" and store it
        var abilityInfo = GameObject.Find("Ability Info").GetComponent<AbilityInfo>(); // Find the "Ability Info" object and store the Ability Info script from it
        if (otherAbility != null)
        { // If the other ability is not null,
            if (thisAbility != otherAbility.name)
            { // If the stored ability does not share the same name as the other ability,
                if (otherAbility.name[0] == slotType[0])
                { // If the first letter of the ability has the same first letter as the slot type,
                    thisAbility = otherAbility.name; // Set this ability to the other ability
                    abilityIcon = otherAbility.GetComponent<SpriteRenderer>().sprite; // Set the ability icon to the ability's sprite
                    abilityCooldown = otherAbility.GetComponent<Cooldown>().cooldown; // Set the ability cooldown to the ability's cooldown
                    AbilityLoader.abilitySlotAbilities.RemoveAt(slotID); // Remove this ability in ability slot mangement's ability array in the slot ID value
                    AbilityLoader.abilitySlotIcons.RemoveAt(slotID); // Remove the ability icon in ability slot mangement's icon ability array in the slot ID value
                    AbilityLoader.abilitySlotCooldowns.RemoveAt(slotID); // Remove the ability cooldown in ability slot mangement's cooldown array in the slot ID value
                    AbilityLoader.abilitySlotAbilities.Insert(slotID, thisAbility); // Store this ability in ability slot mangement's ability array in the slot ID value
                    AbilityLoader.abilitySlotIcons.Insert(slotID, abilityIcon); // Store the ability icon in ability slot mangement's icon array in the slot ID value
                    AbilityLoader.abilitySlotCooldowns.Insert(slotID, abilityCooldown); // Store the ability cooldown in ability slot mangement's cooldown array in the slot ID value
                    maxAbilityCooldown = abilityCooldown; // Set the max value of the cooldown to the ability cooldown
                    iconImage.gameObject.SetActive(true); // Enable the icon image
                    iconImage.sprite = abilityIcon; // Set the sprite of the icon to the ability icon
                    Destroy(GameObject.FindGameObjectWithTag("Ability")); // Destroy the ability (all required information has been stored)
                    abilityInfo.abilityName.text = ""; // Set the ability info name to nothing
                    abilityInfo.abilitySlot.text = ""; // Set the ability info slot to nothing
                    abilityInfo.abilityType.text = ""; // Set the ability info type to nothing
                    abilityInfo.abilityDescription.text = ""; // Set the ability info description to nothing
                    abilityInfo.abilityIcon.sprite = null; // Set the ability info icon to nothing
                    abilityInfo.abilityIcon.gameObject.SetActive(false); // Disable the ability info icon
                }
            }
            else
            { // If this ability does equal the other ability's name, or if the first letter of the ability does not match the first letter of the slot type,
                Destroy(GameObject.FindGameObjectWithTag("Ability")); // Destroy the ability
                abilityInfo.abilityName.text = ""; // Set the ability info name to nothing
                abilityInfo.abilitySlot.text = ""; // Set the ability info slot to nothing
                abilityInfo.abilityType.text = ""; // Set the ability info type to nothing
                abilityInfo.abilityDescription.text = ""; // Set the ability info description to nothing
                abilityInfo.abilityIcon.sprite = null; // Set the ability info icon to nothing
                abilityInfo.abilityIcon.gameObject.SetActive(false); // Disable the ability info icon
            }
        }
    }

    // Function for loading ability information
    public void AbilityLoad(string abilities, Sprite icons, int cooldowns)
    {
        thisAbility = abilities; // Set this ability to the saved abilty
        abilityIcon = icons; // Set the ability icon to the saved icon
        abilityCooldown = cooldowns; // Set the ability cooldown to the saved cooldown
        maxAbilityCooldown = abilityCooldown; // Set the max cooldown to the ability cooldown
        iconImage.gameObject.SetActive(true); // Enable the icon image
        iconImage.sprite = abilityIcon; // Set the sprite of the icon to the ability icon
        cooldownText.gameObject.SetActive(true); // Enable the ability cooldown text
        cooldownText.text = "" + abilityCooldown; // Display the ability cooldown
    }
    
    // Function for decreasing the cooldown
    public void DecreaseCooldown()
    {
        abilityCooldown--; // Decrease the ability cooldown by 1
        if (cooldownText.text != null)
        { // If cooldown text exists,
            cooldownText.text = "" + abilityCooldown; // Display the new ability cooldown
        }
        if (abilityCooldown <= 0)
        { // If ability cooldown is less than or equal to 0,
            cooldownText.gameObject.SetActive(false); // Disable the ability cooldown text
        }
    }

    // Function for resetting the cooldown
    public void ResetCooldown()
    {
        if (abilityCooldown <= 0)
        { // If the ability cooldown is less than or equal to 0,
            abilityCooldown = maxAbilityCooldown; // Set the abiltiy cooldown to the max cooldown
            cooldownText.gameObject.SetActive(true); // Enable the ability cooldown text
            cooldownText.text = "" + abilityCooldown; // Display the new ability cooldown
        }
    }

    // Function for getting an ability ready for use
    public void AbilityPreusage()
    {
        if (thisAbility != null)
        { // If this ability is not null,
            if (abilityCooldown <= 0)
            { // If the ability cooldown is less than or equal to 0,
                var AbilityManager = GameObject.Find("Ability Manager").GetComponent<AbilityManager>(); // Find the ability manager and store it
                AbilityManager.AbilityPreuse(thisAbility, this.gameObject); // Set the ability manager's preuse script to use the ability stored in this slot
            }
        }
    }
}
