using System.Collections.Generic;
using UnityEngine;

public class ComboScore : MonoBehaviour
{
    public ItemGrid bagInventoryGrid;
    [SerializeField] List<InventoryItem> itemsToDestroy = new();
    
    bool isFull = true;

    private void DestroyLineGivePoints()
    {
        Debug.Log("almost");
        for (int i = 0; i < itemsToDestroy.Count; i++)
        {
            Debug.Log(itemsToDestroy[i].gameObject.name);
            //Destroy(itemsToDestroy[i]);

            bagInventoryGrid.DestroyItem(itemsToDestroy[i]);
        }

        for (int i = 0; i < itemsToDestroy.Count; i++)
        {
            Destroy(itemsToDestroy[i].gameObject);
        }
    }

    public bool CheckItem()
    {
        for (int x = 0; x < bagInventoryGrid.GridSizeWidth; x++)
        {
            isFull = true;
            for (int y = 0; y < bagInventoryGrid.GridSizeHeight; y++)
            { 
                if (bagInventoryGrid.inventoryItemSlot[x, y] == null)
                {
                    Debug.Log($"Cell {x},{y} is empty");
                    isFull = false;
                    itemsToDestroy.Clear();
                    continue;
                }
                itemsToDestroy.Add(bagInventoryGrid.inventoryItemSlot[x, y]);
            }

            if (isFull)
            {
                DestroyLineGivePoints();
                break;
            }

        }
        return false;
    }


}
