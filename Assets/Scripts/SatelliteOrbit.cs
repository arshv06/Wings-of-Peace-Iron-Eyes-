using UnityEngine;

public class DroneCameraRotation : MonoBehaviour
{
    public Transform centerPoint;  // The center of the circular orbit (this should be the center of the CRT screen)
    public float orbitRadius = 100f;  // The radius of the orbit, how far from the center the satellite image will rotate
    public float orbitSpeed = 20f;  // The speed of the orbit, how fast the camera rotates
    public bool clockwise = true;   // Determines if the rotation is clockwise or counterclockwise

    private float angle = 0f;

    void Update()
    {
        // Update the angle based on time and orbit speed
        angle += (clockwise ? 1 : -1) * orbitSpeed * Time.deltaTime;

        // Convert the angle to radians for circular motion calculations
        float radians = angle * Mathf.Deg2Rad;

        // Calculate the new X and Y position for circular movement
        float x = Mathf.Cos(radians) * orbitRadius;
        float y = Mathf.Sin(radians) * orbitRadius;

        // Set the new position of the satellite image, keeping it orbiting around the center point
        transform.localPosition = new Vector3(centerPoint.localPosition.x + x, centerPoint.localPosition.y + y, 0);
    }
}
