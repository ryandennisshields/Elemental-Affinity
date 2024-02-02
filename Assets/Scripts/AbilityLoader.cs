using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Class for ability loading
// This code manages ability slot information between scenes.
public class AbilityLoader : MonoBehaviour
{
    public static List<GameObject> abilitySlots; // Stores the ability slots

    public static List<string> abilitySlotAbilities; // Stores the ability slot abilities
    public static List<Sprite> abilitySlotIcons; // Stores the ability slot icons
    public static List<int> abilitySlotCooldowns; // Stores the ability slot cooldowns

    // Awake is called at the start of the program
    private void Awake()
    {
        DontDestroyOnLoad(gameObject); // Set this object to not destroy on switching scenes
    }

    // Start is called before the first frame update
    void Start()
    {
        //execute = true;
        abilitySlots = new List<GameObject>(); // Initialise the ability slot list
        abilitySlotAbilities = new List<string>(); // Initialise the ability slot ability list
        abilitySlotIcons = new List<Sprite>(); // Initialise the ability slot icon list
        abilitySlotCooldowns = new List<int>(); // Intialise the abiltiy slot cooldown list
    }


    // Function for initialising the slots
    public void InitialiseSlots()
    {
        var slots = GameObject.FindGameObjectsWithTag("Ability Slot");
        if (slots != null)
        {
            foreach (GameObject slot in slots)
            { // For each object with the tag "Ability Slot",
                abilitySlots.Add(slot); // Add that slot to the ability slot list
            }
            for (int i = 0; i < abilitySlots.Count; i++)
            { // Fill every every slot with empty values
                abilitySlotAbilities.Add("null");
                abilitySlotIcons.Add(null);
                abilitySlotCooldowns.Add(0);
            }
        }
    }

    // Function for loading abilities
    public static IEnumerator AbilityLoading()
    {
        yield return new WaitForSeconds(0.2f); // Wait for 0.2 seconds
        Dictionary<int, GameObject> slotDict = new Dictionary<int, GameObject>(); // Create a dictionary to store the objects with their slot IDs
        foreach (GameObject slot in GameObject.FindGameObjectsWithTag("Ability Slot"))
        { // For each ability slot,
            int slotID = slot.GetComponent<AbilitySlot>().slotID; // Get the slot ID of the slot
            slotDict.Add(slotID, slot); // Add the slot ID to the dictionary
        }
        var sortedDict = slotDict.OrderBy(x => x.Key); // Sort the dictionary based on the key (the slot ID)
        List<GameObject> abilitySlots = new List<GameObject>(); // Create a new list
        foreach (var slotIDvalue in sortedDict)
        { // For each slot ID value in the sorted dictionary
            abilitySlots.Add(slotIDvalue.Value); // Add the ability slot using the ability ID
        }
        for (int i = 0; i < abilitySlots.Count; i++)
        { // For each ability stored in an ability slot,
            // Current slot depends on the i value
            if (i >= 0 && i < abilitySlots.Count && abilitySlotAbilities[i] != "null")
            { // If the ability slot ability does not equal null,
                var slots = abilitySlots[i]; // Store the current slot
                var abilities = abilitySlotAbilities[i]; // Store the current ability
                var icons = abilitySlotIcons[i]; // Store the current icon
                var cooldowns = abilitySlotCooldowns[i]; // Store the current ability cooldown
                slots.GetComponent<AbilitySlot>().AbilityLoad(abilities, icons, cooldowns); // Set the current slot's ability and ability icon to the current saved ability and icon
            }
        }
    }
}

