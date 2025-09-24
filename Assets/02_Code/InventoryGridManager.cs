using UnityEngine;

public class InventoryGridManager : MonoBehaviour
{
    public int gridWidth = 5;
    public int gridHeight = 5;

    private Inventory[,] slotOccupiedByItem;  // tracks which item occupies each slot
    private Vector2 slotSize = new Vector2(100, 100);

    private void Awake()
    {
        slotOccupiedByItem = new Inventory[gridWidth, gridHeight];
    }

    public Vector2 GetSlotSize()
    {
        return slotSize;
    }


    // check if item can be placed at the grid position
    public bool CanPlaceItem(int itemWidth, int itemHeight, int startX, int startY)
    {
        Debug.Log($"{startX},{itemWidth},{startY},{itemHeight}");
        if (startX + itemWidth > gridWidth || startY + itemHeight > gridHeight) return false;
        for (int x = 0; x < itemWidth; x++)
        {
            for (int y = 0; y < itemHeight; y++)
            {
                if (slotOccupiedByItem[startX + x, startY + y] != null)
                    return false;
            }
        }
        return true;
    }

    // mark slots as occupied by the item
    public void PlaceItem(Inventory item, int startX, int startY)
    {
        for (int x = 0; x < item.itemWidth; x++)
        {
            for (int y = 0; y < item.itemHeight; y++)
            {
                slotOccupiedByItem[startX + x, startY + y] = item;
            }
        }

        // store item's grid start position for easier removal later
        item.gridX = startX;
        item.gridY = startY;
    }

    public void RemoveItem(Inventory item)
    {
        // remove the item from all slots it occupies based on current recorded position and size
        for (int x = 0; x < item.itemWidth; x++)
        {
            for (int y = 0; y < item.itemHeight; y++)
            {
                int slotX = item.gridX + x;
                int slotY = item.gridY + y;

                if (slotX >= 0 && slotX < gridWidth && slotY >= 0 && slotY < gridHeight)
                {
                    if (slotOccupiedByItem[slotX, slotY] == item)
                    {
                        slotOccupiedByItem[slotX, slotY] = null;
                    }
                }
            }
        }

        // reset item's grid position variables
        item.gridX = -1;
        item.gridY = -1;
    }
}
