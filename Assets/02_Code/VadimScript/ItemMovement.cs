using Unity.VisualScripting;
using UnityEngine;

public class ItemMovement : MonoBehaviour
{
    public float speed = 10.0f;
    private Rigidbody2D rb;
    private Vector2 screenBounds;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector2(-speed, 0);
        screenBounds = Camera.main.ScreenToWorldPoint(
            new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z)
        );
    }

    void Update()
    {
        if (transform.position.x < screenBounds.x * -2)
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
