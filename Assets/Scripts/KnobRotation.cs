using UnityEngine;
using TMPro;

public class KnobRotation : MonoBehaviour
{
    public RectTransform knobX;  // Reference to the X knob RectTransform
    public RectTransform knobY;  // Reference to the Y knob RectTransform
    public TextMeshProUGUI xDisplay;  // LED-style display for X value
    public TextMeshProUGUI yDisplay;  // LED-style display for Y value
    public RectTransform crosshair;  // The crosshair to move on the map
    public RectTransform map;  // The map on which the crosshair moves

    private float minAngle = -135f;  // Minimum rotation angle of the knob
    private float maxAngle = 135f;   // Maximum rotation angle of the knob
    private int minCoordinate = -9;  // Change this to -9
    private int maxCoordinate = 9;   // Change this to +9

    private bool isRotatingX = false;  // Whether the X knob is being rotated
    private bool isRotatingY = false;  // Whether the Y knob is being rotated

    private float currentAngleX = 0f;  // Current rotation angle of X knob
    private float currentAngleY = 0f;  // Current rotation angle of Y knob

    void Update()
    {
        // Handle X knob rotation
        if (isRotatingX)
        {
            currentAngleX = RotateKnob(knobX, currentAngleX);
            int xCoordinate = CalculateCoordinate(currentAngleX);
            xDisplay.text = xCoordinate.ToString();  // Update the X display
            UpdateCrosshairPosition(xCoordinate, yCoordinate: null);  // Update crosshair X
        }

        // Handle Y knob rotation
        if (isRotatingY)
        {
            currentAngleY = RotateKnob(knobY, currentAngleY);
            int yCoordinate = CalculateCoordinate(currentAngleY);
            yDisplay.text = yCoordinate.ToString();  // Update the Y display
            UpdateCrosshairPosition(xCoordinate: null, yCoordinate);  // Update crosshair Y
        }
    }

    // Method to detect if the X knob is being rotated (on pointer down)
    public void StartRotateX()
    {
        isRotatingX = true;
    }

    // Method to stop rotating the X knob (on pointer up)
    public void StopRotateX()
    {
        isRotatingX = false;
    }

    // Method to detect if the Y knob is being rotated (on pointer down)
    public void StartRotateY()
    {
        isRotatingY = true;
    }

    // Method to stop rotating the Y knob (on pointer up)
    public void StopRotateY()
    {
        isRotatingY = false;
    }

    // Rotate the knob and return the updated angle
    private float RotateKnob(RectTransform knob, float currentAngle)
    {
        Vector2 direction = Input.mousePosition - knob.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        float clampedAngle = Mathf.Clamp(angle, minAngle, maxAngle);  // Limit rotation to range
        knob.rotation = Quaternion.Euler(0, 0, clampedAngle);  // Apply rotation to the knob
        return clampedAngle;
    }

    // Convert the rotation angle to a coordinate value (now -9 to +9)
    private int CalculateCoordinate(float angle)
    {
        float t = Mathf.InverseLerp(minAngle, maxAngle, angle);  // Normalize angle to a 0-1 value
        return Mathf.RoundToInt(Mathf.Lerp(minCoordinate, maxCoordinate, t));  // Map to -9 to +9 range
    }

    // Update the crosshair's position based on the X and Y coordinates
    private void UpdateCrosshairPosition(int? xCoordinate, int? yCoordinate)
    {
        Vector2 crosshairPos = crosshair.anchoredPosition;

        if (xCoordinate.HasValue)
        {
            crosshairPos.x = Mathf.Lerp(-map.rect.width / 2, map.rect.width / 2, (xCoordinate.Value - minCoordinate) / (float)(maxCoordinate - minCoordinate));
        }

        if (yCoordinate.HasValue)
        {
            crosshairPos.y = Mathf.Lerp(-map.rect.height / 2, map.rect.height / 2, (yCoordinate.Value - minCoordinate) / (float)(maxCoordinate - minCoordinate));
        }

        crosshair.anchoredPosition = crosshairPos;  // Apply the updated position
    }
}
