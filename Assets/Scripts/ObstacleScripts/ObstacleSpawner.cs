using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;    // Prefab to spawn
    [SerializeField] private float upperBoundY = 4000f;    // Y limit before destroying obstacles

    [SerializeField, Min(0f)] private float randomRange = 10f; // Radius for random spawn offsets

    private float timer = 0f;
    private float spawnInterval;                           // Random delay between spawns
    private Vector3 origin;                                // Where spawning is centered

    // Predefined min/max for spawn interval (magic numbers removed)
    [SerializeField] private float minSpawnInterval = 0f;
    [SerializeField] private float maxSpawnInterval = 3f;

    void Start()
    {
        origin = transform.position;                       // Initial spawn center

        // Random time until the first spawn
        spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
    }

    void Update()
    {
        timer += Time.deltaTime;                           // Count time each frame

        // When it's time to spawn again
        if (timer >= spawnInterval)
        {
            timer = 0f;

            // Next spawn delay is randomized again
            spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);

            // Create a randomized spawn position around origin
            Vector3 spawnPos = origin + new Vector3(
                Random.Range(-randomRange, randomRange),
                Random.Range(-randomRange, randomRange),
                Random.Range(-randomRange, randomRange)
            );

            // Spawn the obstacle
            GameObject obstacle =
                Instantiate(obstaclePrefab, spawnPos, Quaternion.identity);

            // Add destroy script dynamically & configure limit
            DestroyWhenOutOfBounds destroyScript =
                obstacle.AddComponent<DestroyWhenOutOfBounds>();

            destroyScript.upperBoundY = upperBoundY;
        }
    }
}

public class DestroyWhenOutOfBounds : MonoBehaviour
{
    public float upperBoundY;   // Y limit provided by spawner

    void Update()
    {
        // Destroy the obstacle once it rises too high
        if (transform.position.y >= upperBoundY)
        {
            Destroy(gameObject);
            Debug.Log("Destroyed");
        }
    }
}
