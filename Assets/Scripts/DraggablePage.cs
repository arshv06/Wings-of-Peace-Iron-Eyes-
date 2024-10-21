using UnityEngine;
using UnityEngine.EventSystems;

public class DraggablePage : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private Canvas parentCanvas;
    private Vector2 offset;  // Offset to avoid jumping

    void Start()
    {
        // Get the RectTransform of the page for movement
        rectTransform = GetComponent<RectTransform>();

        // Get the parent canvas to help with movement scaling
        parentCanvas = GetComponentInParent<Canvas>();
    }

    // Called when the player starts dragging
    public void OnBeginDrag(PointerEventData eventData)
    {
        // Convert the screen point to local point in the page's RectTransform to get the offset
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, eventData.position, eventData.pressEventCamera, out offset);
    }

    // Called while dragging the page
    public void OnDrag(PointerEventData eventData)
    {
        // Convert the screen point to local coordinates within the parent canvas
        Vector2 localPointerPosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(parentCanvas.GetComponent<RectTransform>(), eventData.position, eventData.pressEventCamera, out localPointerPosition);

        // Apply the offset so the page doesn't jump
        Vector2 newPosition = localPointerPosition - offset;

        // Set the position of the Top Secret Page to the new position
        rectTransform.anchoredPosition = newPosition;
    }

    // Called when the player stops dragging (optional behavior can be added here)
    public void OnEndDrag(PointerEventData eventData)
    {
        // You can add behavior here if you want something to happen when the dragging ends
    }
}
