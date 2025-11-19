using UnityEngine;

public class GenerateItem1 : MonoBehaviour
{
    InventoryController inventoryController;

    void Awake()
    {
        inventoryController = FindObjectOfType<InventoryController>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("GenerateItem1 Triggered");
        inventoryController.CreateItem1();
        Destroy(this.gameObject);
    }
}
