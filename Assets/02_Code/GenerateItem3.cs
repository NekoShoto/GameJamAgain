using UnityEngine;

public class GenerateItem3 : MonoBehaviour
{
    InventoryController inventoryController;

    void Awake()
    {
        inventoryController = FindObjectOfType<InventoryController>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("GenerateItem3 Triggered");
        inventoryController.CreateItem3();
        Destroy(this.gameObject);
    }
}
