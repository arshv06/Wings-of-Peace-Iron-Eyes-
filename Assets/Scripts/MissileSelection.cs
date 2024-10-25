using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MissileSelectionScreen : MonoBehaviour
{
    public Button missile1Button;  // Button for Missile 1
    public Button missile2Button;  // Button for Missile 2
    public Button zoomButton;      // Zoom button to show the minimap
    public Image displayScreen;    // Image on the screen
    public TextMeshProUGUI descriptionText;  // Text for missile description
    public Image missile1LED;      // LED for Missile 1
    public Image missile2LED;      // LED for Missile 2
    public Sprite missile1Image;   // Image for Missile 1
    public Sprite missile2Image;   // Image for Missile 2
    public string missile1Description;  // Description for Missile 1
    public string missile2Description;  // Description for Missile 2
    public Color ledOnColor = Color.green;  // Color when the LED is ON (green)
    public Color ledOffColor = Color.red;   // Color when the LED is OFF (red)

    public RectTransform minimapCrosshair;  // Reference to the mini-map crosshair
    public Sprite missile1CrosshairSprite;  // Crosshair sprite for Missile 1 (large spread)
    public Sprite missile2CrosshairSprite;  // Crosshair sprite for Missile 2 (precise target)

    private int selectedMissile = 0;  // Store the selected missile (0 = none, 1 = Missile 1, 2 = Missile 2)
    private bool zoomPressed = false;  // To track if zoom button is pressed

    private void Start()
    {
        // Initialize the buttons and add listeners for clicks
        missile1Button.onClick.AddListener(SelectMissile1);
        missile2Button.onClick.AddListener(SelectMissile2);
        zoomButton.onClick.AddListener(OnZoomButtonPressed);

        // Initially hide the crosshair
        minimapCrosshair.gameObject.SetActive(false);

        // Disable the zoom button until a missile is selected
        zoomButton.interactable = false;
    }

    // Method to select Missile 1
    private void SelectMissile1()
    {
        selectedMissile = 1;
        displayScreen.sprite = missile1Image;  // Show Missile 1 image
        descriptionText.text = missile1Description;  // Set Missile 1 description

        // Set Missile 1 LED to green and Missile 2 LED to red
        missile1LED.color = ledOnColor;
        missile2LED.color = ledOffColor;

        // Enable the zoom button, but don't show the crosshair until zoom is pressed
        zoomButton.interactable = true;
    }

    // Method to select Missile 2
    private void SelectMissile2()
    {
        selectedMissile = 2;
        displayScreen.sprite = missile2Image;  // Show Missile 2 image
        descriptionText.text = missile2Description;  // Set Missile 2 description

        // Set Missile 2 LED to green and Missile 1 LED to red
        missile1LED.color = ledOffColor;
        missile2LED.color = ledOnColor;

        // Enable the zoom button, but don't show the crosshair until zoom is pressed
        zoomButton.interactable = true;
    }

    // Method when the zoom button is pressed
    private void OnZoomButtonPressed()
    {
        if (selectedMissile == 0) return;  // No missile selected, do nothing

        zoomPressed = true;

        // Now show the crosshair based on the selected missile
        minimapCrosshair.gameObject.SetActive(true);

        if (selectedMissile == 1)
        {
            // Show Missile 1 crosshair
            minimapCrosshair.GetComponent<Image>().sprite = missile1CrosshairSprite;
        }
        else if (selectedMissile == 2)
        {
            // Show Missile 2 crosshair
            minimapCrosshair.GetComponent<Image>().sprite = missile2CrosshairSprite;
        }
    }

    // Method to hide the crosshair when needed
    public void HideCrosshair()
    {
        minimapCrosshair.gameObject.SetActive(false);
        zoomPressed = false;
    }
}
