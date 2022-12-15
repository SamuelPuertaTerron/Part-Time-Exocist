using UnityEngine;

public class SpawnGameObject : MonoBehaviour
{
    public GameObject gameObjectToSpawn; // The game object that will be spawned
    public float spawnThreshold = 0.5f;  // The threshold at which the game object will be spawned

    void Update()
    {
        // Get the current light intensity
        float currentLightIntensity = GetCurrentLightIntensity();

        // Check if the current light intensity is below the spawn threshold
        if (currentLightIntensity < spawnThreshold)
        {
            // Spawn the game object
            Instantiate(gameObjectToSpawn, transform.position, transform.rotation);
        }
    }

    float GetCurrentLightIntensity()
    {
       return 1.0f;
    }
}

