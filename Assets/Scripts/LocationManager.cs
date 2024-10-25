using UnityEngine;
using UnityEngine.UI;  // For Image, Button, and other UI elements
using TMPro;  // For TextMeshProUGUI (TextMesh Pro elements)

public class LocationManager : MonoBehaviour
{
    public LocationData[] locations;  // Array to hold location data
    public RectTransform[] locationTransforms;  // Positions of locations on the map
    public RectTransform crosshair;  // Reference to the crosshair
    public TextMeshProUGUI locationNameDisplay;  // Display for the location name
    public TextMeshProUGUI locationInfoDisplay;  // Display for the location info
    public Image ledIndicator;  // LED indicator for zoom eligibility
    public Button zoomButton;  // Zoom button
    public Image minimapDisplay;  // The Image UI element for displaying the minimap sprite
    public RectTransform minimapCrosshair;  // Reference to the mini-map crosshair RectTransform
    public KnobRotationMiniMap minimapKnobController;  // Reference to the minimap knob controller
    public TextMeshProUGUI combinedCoordinatesDisplay;  // Display for combined coordinate info
    public KnobRotation knobRotation;  // Reference to the KnobRotation script for the main map

    private int currentLocationIndex = -1;  // Keep track of the current location

    void Start()
    {
        // Ensure the mini-map crosshair is invisible at the start
        minimapCrosshair.gameObject.SetActive(false);
    }

    void Update()
    {
        bool isValidLocation = false;

        // Check if the crosshair is over any specific locations
        for (int i = 0; i < locations.Length; i++)
        {
            if (IsCrosshairOverLocation(locationTransforms[i]))
            {
                // Display the location's name and info
                locationNameDisplay.text = locations[i].locationName;
                locationInfoDisplay.text = locations[i].locationInfo;

                // Set LED to green and enable the zoom button
                ledIndicator.color = Color.green;
                zoomButton.interactable = true;  // Enable zoom button
                isValidLocation = true;
                currentLocationIndex = i;  // Store the current location index
                return;
            }
        }

        // Clear display if the crosshair is not over a specific location
        locationNameDisplay.text = "";
        locationInfoDisplay.text = "";

        // Set LED to red and disable zoom button if no valid location
        if (!isValidLocation)
        {
            ledIndicator.color = Color.red;
            zoomButton.interactable = false;  // Disable zoom button
            currentLocationIndex = -1;  // Reset the location index
        }
    }

    // Zoom button logic
    public void OnZoomButtonPressed()
    {
        if (currentLocationIndex >= 0)
        {
            // Load the zoomed minimap image for the selected location
            minimapDisplay.sprite = locations[currentLocationIndex].minimapSprite;

            // Check if the minimap sprite is loaded successfully
            if (minimapDisplay.sprite != null)
            {
                // Make the mini-map crosshair visible after the sprite is loaded
                minimapCrosshair.gameObject.SetActive(true);

                // Get the current X and Y coordinates from the big map's crosshair position via KnobRotation instance
                int bigMapX = knobRotation.currentBigMapX;  // Get X value from KnobRotation
                int bigMapY = knobRotation.currentBigMapY;  // Get Y value from KnobRotation
                UpdateCombinedCoordinates(bigMapX, bigMapY, 0, 0);  // Assuming mini-map starts at (0,0)

                // Activate the minimap controls and pass the big map's X and Y coordinates
                minimapKnobController.ActivateMinimapControls(bigMapX, bigMapY);
            }
            else
            {
                // If no sprite is loaded, keep the mini-map crosshair hidden
                minimapCrosshair.gameObject.SetActive(false);
            }
        }
    }

    // Update the combined coordinate display (big map and mini-map)
    public void UpdateCombinedCoordinates(int bigMapX, int bigMapY, int miniMapX, int miniMapY)
    {
        combinedCoordinatesDisplay.text = $"N {bigMapX}.{miniMapX}, E {bigMapY}.{miniMapY}";
    }

    // Check if the crosshair is over a location by comparing distances
    private bool IsCrosshairOverLocation(RectTransform locationTransform)
    {
        // Get the screen position of the crosshair and the location
        Vector2 crosshairPos = crosshair.anchoredPosition;
        Vector2 locationPos = locationTransform.anchoredPosition;

        // Adjust the detection threshold as needed
        float detectionThreshold = 20f;

        // Use distance to check if the crosshair is over the location
        return Vector2.Distance(crosshairPos, locationPos) < detectionThreshold;
    }
}
