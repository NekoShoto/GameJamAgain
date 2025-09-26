using Unity.VisualScripting;
using UnityEngine;

public class ItemMovement : MonoBehaviour
{
    private Vector2 screenBounds;

    void Start()
    {

    }

    void Update()
    {
        if (transform.position.x < -1.2)
        {
            Debug.Log("Bat destroyed at position: " + transform.position);
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Bat collided with player at position: " + transform.position);
            Destroy(this.gameObject);
        }
    }
}