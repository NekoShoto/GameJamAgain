using UnityEngine;

public class MovingFloor : MonoBehaviour
{
    public float speed = 2f;

    public float threasholdPosition = -5.1f;
    public float resetPosition = 4f;

    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        if (transform.position.x < threasholdPosition)
            transform.position += Vector3.right* resetPosition;
    }
}
