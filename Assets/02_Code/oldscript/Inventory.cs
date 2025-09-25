using UnityEngine;
using UnityEngine.EventSystems;

public class Inventory : MonoBehaviour, IPointerDownHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private Canvas canvas;

    public int itemWidth = 2;  // woth of item
    public int itemHeight = 1; // height of item

    // grid coordinates where the item currently resides (-1 is not placed)
    public int gridX = -1;
    public int gridY = -1;

    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;

    InventoryGridManager gridManager;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        gridManager = FindObjectOfType<InventoryGridManager>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
        gridManager.RemoveItem(this);
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // logic before starting drag idk what to place here
    }

    // Resize and reposition the rect transform to cover multiple slots not sure i like it but the video use it still gonna change it
    public void SetPositionAndSize(Vector2 anchoredPos, Vector2 slotSize)
    {
        rectTransform.anchoredPosition = anchoredPos;
        rectTransform.sizeDelta = new Vector2(slotSize.x * itemWidth, slotSize.y * itemHeight);
    }
}
