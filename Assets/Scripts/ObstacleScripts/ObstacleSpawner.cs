using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private float upperBoundY = 4000f;

    [SerializeField, Min(0f)] private float randomRange = 10f;

    private float timer = 0f;
    private float spawnInterval;
    private Vector3 origin;

    void Start()
    {
        origin = transform.position;
        spawnInterval = Random.Range(0f, 3f);
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            timer = 0f;
            spawnInterval = Random.Range(0f, 3f); // NEW RANDOM DELAY

            // Random spawn around spawner origin
            Vector3 spawnPos = origin + new Vector3(
                Random.Range(-randomRange, randomRange),
                Random.Range(-randomRange, randomRange),
                Random.Range(-randomRange, randomRange)
            );

            GameObject obstacle =
                Instantiate(obstaclePrefab, spawnPos, Quaternion.identity);

            DestroyWhenOutOfBounds destroyScript =
                obstacle.AddComponent<DestroyWhenOutOfBounds>();

            destroyScript.upperBoundY = upperBoundY;
        }
    }
}

public class DestroyWhenOutOfBounds : MonoBehaviour
{
    public float upperBoundY;

    void Update()
    {
        if (transform.position.y >= upperBoundY)
        {
            Destroy(gameObject);
            Debug.Log("Destroyed");
        }
    }
}
