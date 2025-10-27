using UnityEngine;

public class GenerateItem2 : MonoBehaviour
{
    InventoryController inventoryController;

    void Awake()
    {
        inventoryController = FindObjectOfType<InventoryController>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("GenerateItem2 Triggered");
        inventoryController.CreateItem2();
        Destroy(this.gameObject);
    }
}
