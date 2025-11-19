using System.Collections.Generic;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    [HideInInspector]
    public ItemGrid selectedItemGrid;
    public ItemGrid handInventoryGrid;
    public ItemGrid bagInvetoryGrid;


    public bool shouldCheckCombo;
    public ComboScore checkit;


    InventoryItem selectedItem;
    InventoryItem overlapItem;
    RectTransform rectTransform;
    RectTransform rectTransform2;


    [SerializeField] List<ItemData> items;
    [SerializeField] GameObject itemPrefab;
    [SerializeField] Transform canvasTransform;

    private void Update()
    {
        ItemIconDrag();

        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("blabla");
            LeftMouseButtomPress();
        }
    }

    public void CreateItem1()
    {
        InventoryItem inventoryItem = Instantiate(itemPrefab).GetComponent<InventoryItem>();

        int selectedItemID = 0;  // Always 0 to spawn the first item
        inventoryItem.Set(items[selectedItemID]);

        SpawnItemOnHandInv(inventoryItem);
    }

    public bool SpawnItemOnHandInv(InventoryItem inventoryItem)
    {

        for (int x = 0; x < handInventoryGrid.GridSizeWidth; x++)
        {
            for (int y = 0; y < handInventoryGrid.GridSizeHeight; y++)
            {
               // Debug.Log($"{handInventoryGrid.gameObject.name},{x},{y}");
                if (handInventoryGrid.PlaceItem(inventoryItem, x , y, ref overlapItem))
                {
                    return true;
                }
            }
        }
        return false;
    }

    public void CreateItem2()
    {
        InventoryItem inventoryItem = Instantiate(itemPrefab).GetComponent<InventoryItem>();
        

        int selectedItemID = 1;  // Always 0 to spawn the first item
        inventoryItem.Set(items[selectedItemID]);

        SpawnItemOnHandInv(inventoryItem);
    }

    public void CreateItem3()
    {
        InventoryItem inventoryItem = Instantiate(itemPrefab).GetComponent<InventoryItem>();
        
        int selectedItemID = 2;  // Always 0 to spawn the first item
        inventoryItem.Set(items[selectedItemID]);

        SpawnItemOnHandInv(inventoryItem);
    }

    private void LeftMouseButtomPress()
    {
        if (selectedItemGrid == null)
        {
            return;
        }
        Vector2Int tileGridPosition = selectedItemGrid.GetTileGridPosition(Input.mousePosition);
        //Debug.Log("Grid Position: " + tileGridPosition);
        if (selectedItem == null)
        {
            PickUpItem(tileGridPosition);
        }
        else
        {
            PlaceItem(tileGridPosition);
        }
    }

    private void PlaceItem(Vector2Int tileGridPosition)
    {
        
        // Place item
        bool complete = selectedItemGrid.PlaceItem(selectedItem, tileGridPosition.x, tileGridPosition.y, ref overlapItem);
        if (complete)
        {
            selectedItem.GetComponent<Image>().raycastTarget = true;
            selectedItem = null;
            if(overlapItem != null)
            {
                Debug.Log("placed");
                //selectedItem = overlapItem;
                //rectTransform = selectedItem.GetComponent<RectTransform>();
                overlapItem = null;
            }
        }
        if (shouldCheckCombo)
            checkit.CheckItem();
    }

    private void PickUpItem(Vector2Int tileGridPosition)
    {
        //Debug.Log("im picking u up");
        //pickupItem
        
        selectedItem = selectedItemGrid.PickUpItem(tileGridPosition.x, tileGridPosition.y);
        if (selectedItem != null)
        {
            rectTransform = selectedItem.GetComponent<RectTransform>();
        }
        selectedItem.GetComponent<Image>().raycastTarget = false;
    }

    private void ItemIconDrag()
    {
        if (selectedItem != null)
        {
            rectTransform.position = Input.mousePosition;
        }
    }
}
