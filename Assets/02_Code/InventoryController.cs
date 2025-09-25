using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [HideInInspector]
    public ItemGrid selectedItemGrid;

    InventoryItem selectedItem;

    private void Update()
    {
       if(selectedItemGrid == null) { return; }
       
       if (Input.GetMouseButtonDown(0))
        {
            Vector2Int tileGridPosition = selectedItemGrid.GetTileGridPosition(Input.mousePosition);
            Debug.Log("Grid Position: " + tileGridPosition);
            if (selectedItem == null)
            {
                Debug.Log("Try to place item");
                // Place item
                selectedItemGrid.PlaceItem(selectedItem, tileGridPosition.x, tileGridPosition.y);
                
            }
            else
            {
                Debug.Log("Try to pick up item");
                selectedItem = selectedItemGrid.PickUpItem(tileGridPosition.x, tileGridPosition.y);
            }
        }       
    }
}
