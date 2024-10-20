using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FaxSystemController : MonoBehaviour
{
    // Reference to the Top Secret Page and its text
    public Text topSecretText;  // The text on the Top Secret page
    public Animator faxAnimator; // Animator for the Top Secret page animation
    public Button printButton;   // Button to start printing
    public Image blinkingLED;    // Blinking LED to indicate communication
    public Text faxDisplayText;  // Text for the fax display screen

    // The cryptic message to be printed on the Top Secret page
    private string crypticMessage = "D3c0d3 th3 m3554g3: Launch at N:32.5 E:117.3";

    // LED blink speed
    public float blinkSpeed = 0.5f;
    private bool isBlinking = false;

    void Start()
    {
        // Automatically call ReceiveCommunication when the scene starts
        ReceiveCommunication();

        // Set initial display text
        faxDisplayText.text = "Waiting for Communication...";
        
        // Set initial text on the Top Secret page (hidden initially)
        topSecretText.text = "";

        // Hide the LED initially
        blinkingLED.color = new Color(blinkingLED.color.r, blinkingLED.color.g, blinkingLED.color.b, 0);

        // Disable the print button initially
        printButton.interactable = false;

        // Add listener for the print button
        printButton.onClick.AddListener(StartPrinting);
    }

    // Simulate receiving incoming communication
    public void ReceiveCommunication()
    {
        StartCoroutine(ShowIncomingCommunication());
    }

    IEnumerator ShowIncomingCommunication()
    {
        // Start blinking the LED
        isBlinking = true;
        StartCoroutine(BlinkLED());

        // After a few seconds, change the display text and make the print button interactable
        yield return new WaitForSeconds(3);
        
        // Stop blinking and update the display to "Print Ready"
        isBlinking = false;
        blinkingLED.color = new Color(blinkingLED.color.r, blinkingLED.color.g, blinkingLED.color.b, 0); // Stop LED
        faxDisplayText.text = "Print Ready";
        
        // Enable the print button
        printButton.interactable = true;
    }

    // Coroutine to blink the LED
    IEnumerator BlinkLED()
    {
        while (isBlinking)
        {
            // Toggle the LED's visibility by adjusting its alpha channel
            blinkingLED.color = new Color(blinkingLED.color.r, blinkingLED.color.g, blinkingLED.color.b, blinkingLED.color.a == 0 ? 1 : 0);
            yield return new WaitForSeconds(blinkSpeed);
        }
    }

    // Start the printing process
    public void StartPrinting()
    {
        // Disable the print button while printing
        printButton.interactable = false;

        // Update the fax display to show "Printing..."
        faxDisplayText.text = "Printing...";

        // Start the animation of the Top Secret page coming out of the fax machine
        faxAnimator.SetTrigger("PrintPage");

        // Start the coroutine to print the message onto the Top Secret page
        StartCoroutine(PrintMissionOnPage());
    }

    // Coroutine to print the cryptic message onto the Top Secret page
    IEnumerator PrintMissionOnPage()
    {
        // Clear the text initially
        topSecretText.text = "";

        // Wait until the animation is underway (adjust this based on your animation)
        yield return new WaitForSeconds(1);

        // Type out the cryptic message slowly
        for (int i = 0; i < crypticMessage.Length; i++)
        {
            topSecretText.text += crypticMessage[i];
            yield return new WaitForSeconds(0.05f); // Adjust typing speed
        }

        // After the printing is done, update the fax display text to "Print Complete"
        faxDisplayText.text = "Print Complete";
    }
}
