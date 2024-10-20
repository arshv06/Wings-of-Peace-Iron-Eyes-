using UnityEngine;
using UnityEngine.UI;

public class MapController : MonoBehaviour
{
    // Reference to the UI Text elements
    public Text locationNameText;  // Displays the location name
    public Text locationInfoText;  // Displays the location info

    // Function to handle location clicks
    public void OnLocationClick(string locationName)
    {
        // Log the clicked location
        Debug.Log("Location clicked: " + locationName);

        // Update the UI Text elements based on the location clicked
        switch (locationName)
        {
            case "alaqsafob":
                locationNameText.text = "Al-Aqsa FOB";
                locationInfoText.text = "Our Glorious peace delivering warehouse";
                break;

            case "apartments":
                locationNameText.text = "Apartments";
                locationInfoText.text = "This residential area is densely populated with civilians.";
                break;

            case "fatoom":
                locationNameText.text = "Fatoom Bazaar";
                locationInfoText.text = "An industrial sector known for its factories and production lines.";
                break;

            case "eastemaratschool":
                locationNameText.text = "East Emarat School";
                locationInfoText.text = "A deserted area often used for covert military operations.";
                break;

            case "qarizihospital":
                locationNameText.text = "Qarizi Hospital";
                locationInfoText.text = "The government headquarters, heavily fortified and protected.";
                break;

            case "martyrsquare":
                locationNameText.text = "Martyr Square";
                locationInfoText.text = "The government headquarters, heavily fortified and protected.";
                break;

            default:
                locationNameText.text = "Unknown Location";
                locationInfoText.text = "No information available for this location.";
                break;
        }
    }
}
