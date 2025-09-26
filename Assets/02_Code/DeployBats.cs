using System.Collections;
using UnityEngine;

public class DeployBats : MonoBehaviour
{
    public GameObject[] Prefabs;
    public float randomZRange = 0f;
    private Vector2 screenBounds;
    public Transform parentTransform;

    private GameObject currentBat; // Ссылка на текущий заспавненный объект

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(
            new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z)
        );
    }

    public void SpawnBatAtPosition(Vector3 position)
    {
        if (currentBat == null) // Спавним только если нет активного объекта
        {
            int index = Random.Range(0, Prefabs.Length);
            float randomZ = Random.Range(0f, randomZRange);
            Quaternion randomRotation = Quaternion.Euler(0, 0, randomZ);
            currentBat = Instantiate(Prefabs[index], position, randomRotation, parentTransform);
        }
    }

    void Update()
    {
        Vector3 targetPosition = new Vector3(2.64f, 0.55f, transform.position.z);
        float tolerance = 0.1f;

        if (Vector2.Distance(new Vector2(transform.position.x, transform.position.y), new Vector2(targetPosition.x, targetPosition.y)) < tolerance)
        {
            SpawnBatAtPosition(transform.position);
        }
    }
}