using Unity.VisualScripting;
using UnityEngine;

public class ItemMovement : MonoBehaviour
{
    public float speed = 1f; // speed of movement, units per second

    void Update()
    {
        // Move object left at a constant speed every frame
        transform.position += Vector3.left * speed * Time.deltaTime * 0.25f;

        if (transform.position.x < -3f)
        {
           Destroy(gameObject);
        }
    }
}