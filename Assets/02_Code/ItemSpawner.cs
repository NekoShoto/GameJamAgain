using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class ItemSpawner : MonoBehaviour
{
    // Assign your prefab in the Inspector
    [SerializeField] GameObject[] objectsToSpawn;  // Assign 3 prefabs in Inspector

    // Position where to spawn the object
    public Vector2 spawnPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    
        StartCoroutine(SpawnItemEvery5s());
    }
    IEnumerator SpawnItemEvery5s()
    {
        while (true)  // keep running forever
        {
            
            Spawn();                  // Run your function
            yield return new WaitForSeconds(5f);  // Wait 5 seconds before looping
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        if (objectsToSpawn.Length == 0)
        {
            Debug.LogWarning("No objects assigned for spawning.");
            return;
        }

        int randomIndex = Random.Range(0, objectsToSpawn.Length);
        GameObject prefabToSpawn = objectsToSpawn[randomIndex];

        Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
    }
}
