using UnityEngine;

public class MovingFloor2 : MonoBehaviour
{
    public float speed = 2f;

    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        if (transform.position.x < -2.5)
            transform.position += Vector3.right * 6;
    }
}
