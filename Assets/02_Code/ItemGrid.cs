using System;
using Unity.Mathematics;
using UnityEngine.UI;
using UnityEngine;

public class ItemGrid : MonoBehaviour
{
    public const float tileSizeWidth = 32;
    public const float tileSizeHeight = 32;

    InventoryItem[,] inventoryItemSlot;

    RectTransform rectTransform;

    [SerializeField] int gridSizeWidth = 20;
    [SerializeField] int gridSizeHeight = 10;
    public int GridSizeWidth => gridSizeWidth;
    public int GridSizeHeight => gridSizeWidth;

    public void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        Init(gridSizeWidth, gridSizeHeight);
    }

    private void Init(int width, int height)
    {
        inventoryItemSlot = new InventoryItem[width, height];
        Vector2 size = new Vector2(width * tileSizeWidth, height * tileSizeHeight);
        rectTransform.sizeDelta = size;
    }

    Vector2 positionOnTheGrid = new Vector2();
    Vector2Int tileGridPosition = new Vector2Int();
    public Vector2Int GetTileGridPosition(Vector2 mousePosition)
    {

        positionOnTheGrid.x = mousePosition.x - rectTransform.position.x;
        positionOnTheGrid.y = mousePosition.y - rectTransform.position.y;

        tileGridPosition.x = (int)(positionOnTheGrid.x / tileSizeWidth);
        tileGridPosition.y = (int)(positionOnTheGrid.y / tileSizeHeight);

        tileGridPosition.y = Mathf.Abs(tileGridPosition.y);

        return tileGridPosition;
    }

    public bool PlaceItem(InventoryItem inventoryItem, int posX, int posY, ref InventoryItem overlapItem)
    {
        if (BoundaryCheck(posX, posY, inventoryItem.itemData.width, inventoryItem.itemData.height) == false)
        {
            Debug.Log("Item is out of bounds");
            return false;
        }

        if (OverlapCheck(posX, posY, inventoryItem.itemData.width, inventoryItem.itemData.height, ref overlapItem))
        {
            overlapItem = null;
            return false;
        }

        RectTransform rectTransform = inventoryItem.GetComponent<RectTransform>();
        rectTransform.SetParent(this.rectTransform);
        posY = Mathf.Abs(posY);
        Debug.Log("place up item at: " + posX + ", " + posY);

        for (int x = 0; x < inventoryItem.itemData.width; x++)
        {
            for (int y = 0; y < inventoryItem.itemData.height; y++)
            {
                inventoryItemSlot[posX + x, posY + y] = inventoryItem;
            }
        }
        inventoryItem.onGridPosX = posX;
        inventoryItem.onGridPosY = posY;

        Vector2 position = new Vector2();
        position.x = posX * tileSizeWidth + tileSizeWidth * inventoryItem.itemData.width / 2;
        position.y = -(posY * tileSizeHeight + tileSizeHeight * inventoryItem.itemData.height / 2);

        rectTransform.localPosition = position;

       

        // Ensure all code paths return a value
        return true;
    }

    private bool OverlapCheck(int posX, int posY, int width, int height, ref InventoryItem overlapItem)
    {
        
        for(int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (inventoryItemSlot[posX + x, posY + y] != null)
                {
                    if(overlapItem == null)
                    {
                        Debug.Log("its overlaping false");
                        overlapItem = inventoryItemSlot[posX + x, posY + y];
                    }
                    else if (overlapItem != inventoryItemSlot[posX + x, posY + y])
                    {
                        Debug.Log("its overlaping true");
                        
                    }
                    return true;
                }
            }
        }

        return false;
    }

    public InventoryItem PickUpItem(int x, int y)
    {
        y = Mathf.Abs(y);
        Debug.Log("Pick up item at: " + x + ", " + y);
        if (x < 0 || x >= gridSizeWidth || y < 0 || y >= gridSizeHeight)
            return null;
        InventoryItem toReturn = inventoryItemSlot[x, y];

        if (toReturn == null) { return null; }


        for (int ix = 0; ix < toReturn.itemData.width; ix++)
        {
            for (int iy = 0; iy < toReturn.itemData.height; iy++)
            {
                inventoryItemSlot[toReturn.onGridPosX + ix, toReturn.onGridPosY + iy] = null;
            }
        }
        return toReturn;

    }

    bool PositionCheck(int posX, int posY)
    {
        if (posX < 0 || posY < 0)
        {
            return false;
        }


        if (posX >= gridSizeWidth || posY >= gridSizeHeight)
        {
            return false;
        }


        return true;
    }


    bool BoundaryCheck(int posX, int posY, int width, int height)
    {
        if (PositionCheck(posX, posY) == false)
        {
            return false;
        }

        posX += width -1;
        posY += height -1;

        if (PositionCheck(posX, posY) == false)
        {
            return false;
        }


        return true;
    }
}
