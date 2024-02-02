using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Class for abilities stored in the shop
// This code manages any abilities in the store not currently equipped.
public class AbilityStored : MonoBehaviour
{
    private GameObject ability; // Stores the ability 
    [Header("Ability Values")]
    public string thisAbilityID; // Stores the ability id of this ability
    public Sprite thisAbilityIcon; // Stores the ability icon of this ability
    public string thisAbilityLevel; // Stores the level the ability is available
    public int thisAbilityCooldown; // Stores the ability object of this ability

    private AbilityInfo abilityInfo; // Stores the ability info script
    [Header("Ability Info")]
    public string thisAbilityName; // Stores the ability name of this ability
    public string thisAbilitySlot; // Stores the ability slot of this ability
    public string thisAbilityType; // Stores the ability type of this ability
    public string thisAbilityDescription; // Stores the ability description of this ability

    [Header("Stored Values")]
    public GameObject equippableAbility; // Stores the equippable ability
    public Image iconImage; // Stores the icon
    public TextMeshProUGUI leveltoUnlock; // Stores text showing what level until the ability is unlocked

    // Start is called before the first frame update
    void Start()
    {
        abilityInfo = GameObject.Find("Ability Info").GetComponent<AbilityInfo>(); // Find and set the ability info to the Ability Info component of the "Ability Info" object
        iconImage.sprite = thisAbilityIcon; // Set the icon to this ability's icon
        if (PlayerPrefs.GetFloat(thisAbilityLevel) > 0 || thisAbilityLevel == "1-0")
        { // If the ability level has a score greater than 0 or the ability level is 1-0,
            GetComponent<Button>().interactable = true; // Make the button interactable
            leveltoUnlock.text = ""; // Set the level to unlock text to nothing
        }
        else
        { // If the ability level does not have a score greater than 0,
            GetComponent<Button>().interactable = false; // Make the button uninteractable
            leveltoUnlock.text = "" + thisAbilityLevel; // Set the level to unlock text to the level that this ability requires
        }
    }

    // Function for getting an ability ready for equip
    public void AbilityGetReadyForEquip()
    {
        var existingAbility = GameObject.FindGameObjectWithTag("Ability"); // Find and store a game object with the tag "Ability"
        if (existingAbility == null)
        { // If there is no existing ability,
            ability = Instantiate(equippableAbility); // Instantiate an equippable ability
            ability.name = thisAbilityID; // Set the ability's name to the ability id
            ability.GetComponent<Cooldown>().cooldown = thisAbilityCooldown; // Set the ability's cooldown to this ability's cooldown
            ability.GetComponent<SpriteRenderer>().sprite = thisAbilityIcon; // Set the ability's sprite to this ability's stored icon
            abilityInfo.abilityName.text = thisAbilityName; // Set the ability info name to this ability's name
            abilityInfo.abilitySlot.text = thisAbilitySlot; // Set the ability info slot to this ability's slot
            abilityInfo.abilityType.text = thisAbilityType; // Set the ability info type to this ability's type
            abilityInfo.abilityDescription.text = thisAbilityDescription; // Set the ability info description to this ability's description
            abilityInfo.abilityIcon.gameObject.SetActive(true); // Set the ability info icon to be active
            abilityInfo.abilityIcon.sprite = thisAbilityIcon; // Set the ability info icon sprite to this ability's sprite
        }
        else
        { // If there is an existing ability,
            GameObject[] allAbilities = GameObject.FindGameObjectsWithTag("Ability"); // Find all abilities with the tag "Ability"
            foreach (GameObject ability in allAbilities)
            { // For each ability,
                Destroy(ability); // Destroy the ability
            }
            abilityInfo.abilityName.text = ""; // Set the ability info name to nothing
            abilityInfo.abilitySlot.text = ""; // Set the ability info slot to nothing
            abilityInfo.abilityType.text = ""; // Set the ability info type to nothing
            abilityInfo.abilityDescription.text = ""; // Set the ability info description to nothing
            abilityInfo.abilityIcon.sprite = null; // Set the ability info icon to nothing
            abilityInfo.abilityIcon.gameObject.SetActive(false); // Disable the ability info icon
        }
    }
}
