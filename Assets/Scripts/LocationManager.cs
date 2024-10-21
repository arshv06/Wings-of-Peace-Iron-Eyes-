using UnityEngine;
using TMPro;

public class LocationManager : MonoBehaviour
{
    public LocationData[] locations;  // Array to hold location data
    public RectTransform[] locationTransforms;  // Positions of locations on the map
    public RectTransform crosshair;  // Reference to the crosshair
    public TextMeshProUGUI locationNameDisplay;  // Display for the location name
    public TextMeshProUGUI locationInfoDisplay;  // Display for the location info

    void Update()
    {
        // Check if the crosshair is over any specific locations
        for (int i = 0; i < locations.Length; i++)
        {
            if (IsCrosshairOverLocation(locationTransforms[i]))
            {
                // Display the location's name and info
                locationNameDisplay.text = locations[i].locationName;
                locationInfoDisplay.text = locations[i].locationInfo;
                return;
            }
        }

        // Clear display if the crosshair is not over a specific location
        locationNameDisplay.text = "";
        locationInfoDisplay.text = "";
    }

    // Check if the crosshair is over a location by comparing distances
    private bool IsCrosshairOverLocation(RectTransform locationTransform)
    {
        return Vector2.Distance(crosshair.anchoredPosition, locationTransform.anchoredPosition) < 20f;  // Adjust the distance threshold as needed
    }
}
