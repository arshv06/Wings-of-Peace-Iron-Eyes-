using UnityEngine;
using TMPro;  // For TextMeshProUGUI

public class CountdownTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;  // Reference to the UI Text component for displaying time
    private float timeRemaining = 7 * 60f;  // 7 minutes in seconds
    private bool timerRunning = true;  // Flag to control if the timer is running

    void Start()
    {
        // Initialize the timer text at the start
        UpdateTimerDisplay(timeRemaining);
    }

    void Update()
    {
        // Run the timer if it is active
        if (timerRunning)
        {
            // Reduce time only if there is time remaining
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;  // Subtract the elapsed time
                UpdateTimerDisplay(timeRemaining);  // Update the UI with the remaining time
            }
            else
            {
                timeRemaining = 0;  // Make sure time does not go below zero
                timerRunning = false;  // Stop the timer
                // You can trigger events here, like "Time's up!" or similar
            }
        }
    }

    // Method to update the timer UI
    private void UpdateTimerDisplay(float timeToDisplay)
    {
        // Convert time into minutes and seconds
        int minutes = Mathf.FloorToInt(timeToDisplay / 60);  // Get the minutes
        int seconds = Mathf.FloorToInt(timeToDisplay % 60);  // Get the remaining seconds

        // Format the time to be MM:SS and display it
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
