using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlots : MonoBehaviour, IDropHandler
{
    public int slotX; // grid X coordinate of this slot
    public int slotY; // grid Y coordinate of this slot
    public InventoryGridManager gridManager; // reference to your grid manager

    private RectTransform rectTransform; // the RectTransform of this slot (assumed on the same gameObject)

    private void Awake()
    {
        if (rectTransform == null)
            rectTransform = GetComponent<RectTransform>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        var item = eventData.pointerDrag.GetComponent<Inventory>();
        if (item != null)
        {
            if (gridManager.CanPlaceItem(item.itemWidth, item.itemHeight, slotX, slotY))
            {
                // place the item on the grid
                gridManager.PlaceItem(item, slotX, slotY);

                // position the item visually and resize to cover multiple slots not sure i like it
                Vector2 anchoredPos = rectTransform.anchoredPosition;
                Vector2 slotSize = gridManager.GetSlotSize();
                item.SetPositionAndSize(anchoredPos, slotSize);
            }
            else
            {
                Debug.Log("Cannot place item here - not enough space.");
                // return item to original position or handle invalid drop need to do this
            }
        }
    }
}

