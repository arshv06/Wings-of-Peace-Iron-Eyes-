using UnityEngine;
using UnityEngine.UI;
using TMPro;  // For LED-style display text

public class KnobRotation : MonoBehaviour
{
    public RectTransform knobX;  // Reference to the knob for X-coordinate
    public RectTransform knobY;  // Reference to the knob for Y-coordinate
    public TextMeshProUGUI xDisplay;  // LED-style display for X-coordinate
    public TextMeshProUGUI yDisplay;  // LED-style display for Y-coordinate

    public float minAngle = -135f;  // Minimum rotation angle for the knob
    public float maxAngle = 135f;   // Maximum rotation angle for the knob
    public int minCoordinate = -5;  // Minimum X or Y coordinate value
    public int maxCoordinate = 5;   // Maximum X or Y coordinate value

    private bool isRotatingX = false;  // Tracks if the X knob is being rotated
    private bool isRotatingY = false;  // Tracks if the Y knob is being rotated

    private float currentAngleX = 0f;  // Current rotation angle of the X knob
    private float currentAngleY = 0f;  // Current rotation angle of the Y knob

    void Update()
    {
        // Handle X knob rotation
        if (isRotatingX)
        {
            currentAngleX = RotateKnob(knobX, currentAngleX);
            int xCoordinate = CalculateCoordinate(currentAngleX);
            xDisplay.text = xCoordinate.ToString();  // Update the X coordinate display
        }

        // Handle Y knob rotation
        if (isRotatingY)
        {
            currentAngleY = RotateKnob(knobY, currentAngleY);
            int yCoordinate = CalculateCoordinate(currentAngleY);
            yDisplay.text = yCoordinate.ToString();  // Update the Y coordinate display
        }
    }

    // Method to detect if the X knob is being rotated (on mouse down or touch)
    public void StartRotateX()
    {
        isRotatingX = true;
    }

    // Method to stop rotating the X knob (on mouse up or release)
    public void StopRotateX()
    {
        isRotatingX = false;
    }

    // Method to detect if the Y knob is being rotated (on mouse down or touch)
    public void StartRotateY()
    {
        isRotatingY = true;
    }

    // Method to stop rotating the Y knob (on mouse up or release)
    public void StopRotateY()
    {
        isRotatingY = false;
    }

    // Method to handle knob rotation
    private float RotateKnob(RectTransform knob, float currentAngle)
    {
        Vector2 direction = Input.mousePosition - knob.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        float clampedAngle = Mathf.Clamp(angle, minAngle, maxAngle);  // Limit the rotation angle

        knob.rotation = Quaternion.Euler(0, 0, clampedAngle);  // Apply the rotation
        return clampedAngle;
    }

    // Convert the rotation angle to a coordinate value (e.g., between -5 and +5)
    private int CalculateCoordinate(float angle)
    {
        float t = Mathf.InverseLerp(minAngle, maxAngle, angle);  // Normalize angle to 0-1
        return Mathf.RoundToInt(Mathf.Lerp(minCoordinate, maxCoordinate, t));  // Map to coordinate range
    }
}
