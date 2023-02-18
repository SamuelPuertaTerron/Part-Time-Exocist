using UnityEngine;

public class SpawnRandomObject : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public float minSpawnTime = 1f;
    public float maxSpawnTime = 10f;
    [Range(1,15)] public int _ghostSpawnDistance; 
    private float spawnTimer;
    private float currentTime;
    private int SpawnedObjects;
    


    void Start()
    {
        spawnTimer = Random.Range(minSpawnTime, maxSpawnTime);
        SpawnedObjects = 0;
    }

    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= spawnTimer)
        {
            currentTime = 0;
            spawnTimer = Random.Range(minSpawnTime, maxSpawnTime);

            if (!GameObject.Find(prefabToSpawn.name) && SpawnedObjects < 1)
            {
                Vector3 spawnPosition = Camera.main.transform.position + Camera.main.transform.forward * _ghostSpawnDistance;
                Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
                SpawnedObjects = 2;
            }
        }

       
    }
}
