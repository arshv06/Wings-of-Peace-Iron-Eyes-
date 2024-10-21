using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FaxSystemController : MonoBehaviour
{
    // References for the UI elements
    public Text topSecretText;      // The text on the Top Secret page
    public Animator faxAnimator;    // Animator for the Top Secret page animation
    public Button printButton;      // Button to start printing
    public Image blinkingLED;       // Blinking LED to indicate communication
    public Text faxDisplayText;     // Text for the fax display screen

    // The cryptic message to be printed on the Top Secret page
    private string crypticMessage = "D3c0d3 th3 m3554g3: Launch at N:32.5 E:117.3";

    // LED blink speed and brightness values
    public float blinkSpeed = 0.5f;
    private bool isBlinking = false;
    private float brightAlpha = 1f; // Full brightness alpha
    private float dimAlpha = 0.2f;  // Dim alpha

    void Start()
    {
        ReceiveCommunication();

        // Set initial display text
        faxDisplayText.text = "Waiting for Communication...";

        // Set initial text on the Top Secret page (hidden initially)
        topSecretText.text = crypticMessage;  // Set the cryptic message before animation

        // Initially set the LED to dim (with red color intact) and disable the print button
        SetLEDAlpha(dimAlpha);
        printButton.interactable = false;

        // Add listener for the print button
        printButton.onClick.AddListener(StartPrinting);
    }

    // Set the alpha of the LED without changing the color
    private void SetLEDAlpha(float alpha)
    {
        Color currentColor = blinkingLED.color;
        currentColor.a = alpha;
        blinkingLED.color = currentColor;
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
        SetLEDAlpha(dimAlpha);  // Set the LED to dim when blinking stops
        faxDisplayText.text = "Print Ready";

        // Enable the print button
        printButton.interactable = true;
    }

    // Coroutine to blink the LED (switch between bright and dim alpha)
    IEnumerator BlinkLED()
    {
        while (isBlinking)
        {
            // Toggle the LED between bright and dim by only adjusting the alpha
            SetLEDAlpha(blinkingLED.color.a == brightAlpha ? dimAlpha : brightAlpha);
            yield return new WaitForSeconds(blinkSpeed);
        }

        // After blinking, set the LED to remain dim
        SetLEDAlpha(dimAlpha);
    }

    // Start the printing process (the animation starts but the message is already pre-printed)
    public void StartPrinting()
    {
        // Disable the print button while printing
        printButton.interactable = false;

        // Update the fax display to show "Printing..."
        faxDisplayText.text = "Printing...";

        // Play the animation to simulate the page being printed (message already on the page)
        faxAnimator.SetTrigger("PrintPage");

        // After animation finishes, update the display text
        StartCoroutine(PrintComplete());
    }

    // Coroutine to handle printing completion
    IEnumerator PrintComplete()
    {
        // Wait until the animation completes (adjust timing based on your animation duration)
        yield return new WaitForSeconds(2);

        // After the animation finishes, update the fax display text
        faxDisplayText.text = "Print Complete";
    }
}
