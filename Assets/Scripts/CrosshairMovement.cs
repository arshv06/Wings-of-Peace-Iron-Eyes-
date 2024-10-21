using UnityEngine;
using UnityEngine.UI;

public class CrosshairMovement : MonoBehaviour
{
    public RectTransform crosshair;  // The crosshair image to be moved
    public RectTransform map;  // The map image where the crosshair will move
    public Slider xKnob;  // The knob/slider controlling the X-axis
    public Slider yKnob;  // The knob/slider controlling the Y-axis
    public Text xDisplay;  // UI text to display the X coordinate
    public Text yDisplay;  // UI text to display the Y coordinate

    private float minX = -5f;  // Min value for the X coordinate
    private float maxX = 5f;   // Max value for the X coordinate
    private float minY = -5f;  // Min value for the Y coordinate
    private float maxY = 5f;   // Max value for the Y coordinate

    void Start()
    {
        // Initialize the knob values and add listeners to update the crosshair position
        xKnob.minValue = minX;
        xKnob.maxValue = maxX;
        yKnob.minValue = minY;
        yKnob.maxValue = maxY;

        xKnob.onValueChanged.AddListener(UpdateCrosshairPosition);
        yKnob.onValueChanged.AddListener(UpdateCrosshairPosition);

        // Set the initial position
        UpdateCrosshairPosition(0);
    }

    // Method to update the crosshair position and display the corresponding coordinates
    void UpdateCrosshairPosition(float value)
    {
        // Calculate the X and Y positions relative to the map's size
        float xPos = Mathf.Lerp(-map.rect.width / 2, map.rect.width / 2, (xKnob.value - minX) / (maxX - minX));
        float yPos = Mathf.Lerp(-map.rect.height / 2, map.rect.height / 2, (yKnob.value - minY) / (maxY - minY));

        // Set the crosshair's anchored position on the map
        crosshair.anchoredPosition = new Vector2(xPos, yPos);

        // Update the X and Y coordinate displays
        xDisplay.text = Mathf.RoundToInt(xKnob.value).ToString();
        yDisplay.text = Mathf.RoundToInt(yKnob.value).ToString();
    }
}
