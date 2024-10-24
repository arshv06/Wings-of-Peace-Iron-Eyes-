using UnityEngine;
using UnityEngine.UI;

public class ZoomController : MonoBehaviour
{
    public Button zoomButton;  // Reference to the Zoom Button
    public Image miniMapScreen;  // Mini-map screen to display the zoomed-in image
    public Sprite[] zoomedInImages;  // Array of zoomed-in images for each location
    public RectTransform[] validLocations;  // Array of valid location transforms
    public RectTransform crosshair;  // Reference to the crosshair

    void Start()
    {
        zoomButton.onClick.AddListener(OnZoomButtonClick);
    }

    void OnZoomButtonClick()
    {
        // Find which location the crosshair is on
        for (int i = 0; i < validLocations.Length; i++)
        {
            if (Vector2.Distance(crosshair.anchoredPosition, validLocations[i].anchoredPosition) < 20f)
            {
                miniMapScreen.sprite = zoomedInImages[i];  // Load the corresponding zoomed-in image
                break;
            }
        }
    }
}
