using UnityEngine;

public class KnobRotationMiniMap : MonoBehaviour
{
    public RectTransform knobX;  // Reference to the X knob RectTransform (for the mini-map)
    public RectTransform knobY;  // Reference to the Y knob RectTransform (for the mini-map)
    public RectTransform crosshair;  // The crosshair to move on the mini-map
    public RectTransform minimap;  // The mini-map on which the crosshair moves
    public LocationManager locationManager;  // Reference to the LocationManager

    private float minAngle = -135f;  // Minimum rotation angle of the knob
    private float maxAngle = 135f;   // Maximum rotation angle of the knob
    private int minCoordinate = 0;   // Minimum coordinate value on the mini-map
    private int maxCoordinate = 30;  // Maximum coordinate value on the mini-map

    private bool isRotatingX = false;  // Whether the X knob is being rotated
    private bool isRotatingY = false;  // Whether the Y knob is being rotated

    private float currentAngleX = 0f;  // Current rotation angle of X knob
    private float currentAngleY = 0f;  // Current rotation angle of Y knob

    private int bigMapX = 0;
    private int bigMapY = 0;

    public void ActivateMinimapControls(int bigMapXValue, int bigMapYValue)
    {
        // Store big map coordinates for the combined coordinate display
        bigMapX = bigMapXValue;
        bigMapY = bigMapYValue;
    }

    void Update()
    {
        // Handle X knob rotation
        if (isRotatingX)
        {
            currentAngleX = RotateKnob(knobX, currentAngleX);
            int miniMapX = CalculateCoordinate(currentAngleX);  // Calculate X value for the mini-map
            UpdateCrosshairPosition(miniMapX, yCoordinate: null);  // Update crosshair X position
            locationManager.UpdateCombinedCoordinates(bigMapX, bigMapY, miniMapX, 0);  // Update combined coordinate display for X
        }

        // Handle Y knob rotation
        if (isRotatingY)
        {
            currentAngleY = RotateKnob(knobY, currentAngleY);
            int miniMapY = CalculateCoordinate(currentAngleY);  // Calculate Y value for the mini-map
            UpdateCrosshairPosition(xCoordinate: null, miniMapY);  // Update crosshair Y position
            locationManager.UpdateCombinedCoordinates(bigMapX, bigMapY, 0, miniMapY);  // Update combined coordinate display for Y
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

    // Convert the rotation angle to a coordinate value (e.g., 0 to 30)
    private int CalculateCoordinate(float angle)
    {
        float t = Mathf.InverseLerp(minAngle, maxAngle, angle);  // Normalize angle to a 0-1 value
        return Mathf.RoundToInt(Mathf.Lerp(minCoordinate, maxCoordinate, t));  // Map to 0 to 30 range
    }

    // Update the crosshair's position based on the X and Y coordinates
    private void UpdateCrosshairPosition(int? xCoordinate, int? yCoordinate)
    {
        Vector2 crosshairPos = crosshair.anchoredPosition;

        if (xCoordinate.HasValue)
        {
            crosshairPos.x = Mathf.Lerp(-minimap.rect.width / 2, minimap.rect.width / 2, (xCoordinate.Value - minCoordinate) / (float)(maxCoordinate - minCoordinate));
        }

        if (yCoordinate.HasValue)
        {
            crosshairPos.y = Mathf.Lerp(-minimap.rect.height / 2, minimap.rect.height / 2, (yCoordinate.Value - minCoordinate) / (float)(maxCoordinate - minCoordinate));
        }

        crosshair.anchoredPosition = crosshairPos;  // Apply the updated position
    }
}
