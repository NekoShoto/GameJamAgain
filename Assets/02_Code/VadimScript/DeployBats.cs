using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DeployBats : MonoBehaviour
{
    public GameObject batPrefab;
    public float respawnTime = 1.0f;
    private Vector2 screenBounds;

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(
            new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z)
        );
        StartCoroutine(batWave());
    }

    private void spawnBat()
    {
        GameObject a = Instantiate(batPrefab) as GameObject;
        a.transform.position = this.gameObject.transform.position;
    }

    private IEnumerator batWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnBat();
        }
    }
}
