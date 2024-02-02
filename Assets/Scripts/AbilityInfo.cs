using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Class for ability info
// This code stores ability information, then displays the information on the screen when the player selects it in the shop.
public class AbilityInfo : MonoBehaviour
{
    public TextMeshProUGUI abilityName; // Stores the ability name
    public TextMeshProUGUI abilitySlot; // Stores the ability slot type
    public TextMeshProUGUI abilityType; // Stores the ability effect, element, etc. type
    public TextMeshProUGUI abilityDescription; // Stores the ability description
    public Image abilityIcon; // Stores the ability icon
}
