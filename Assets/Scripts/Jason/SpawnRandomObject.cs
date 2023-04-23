using UnityEngine;

public class SpawnRandomObject : MonoBehaviour
{
    public GameObject[] prefabsToSpawn;  // an array of game objects to choose from
    public float minSpawnTime = 1f;
    public float maxSpawnTime = 10f;
    [Range(1,15)] public int _ghostSpawnDistance; 
    private float spawnTimer;
    private float currentTime;
    private int spawnedObjects;
    
    void Start()
    {
        spawnTimer = Random.Range(minSpawnTime, maxSpawnTime);
        spawnedObjects = 0;
    }

    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= spawnTimer)
        {
            currentTime = 0;
            spawnTimer = Random.Range(minSpawnTime, maxSpawnTime);

            if (spawnedObjects < 1)
            {
                // choose a random prefab from the array
                GameObject prefabToSpawn = prefabsToSpawn[Random.Range(0, prefabsToSpawn.Length)];

                // spawn the selected prefab
                Vector3 spawnPosition = Camera.main.transform.position + Camera.main.transform.forward * _ghostSpawnDistance;
                Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
                spawnedObjects++;
            }
        }
    }
}

