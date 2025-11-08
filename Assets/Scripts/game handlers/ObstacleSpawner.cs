using UnityEngine;

public class RandomObstacleSpawner : MonoBehaviour
{
    [Header("Obstacle Settings")]
    public GameObject[] obstaclePrefabs;    // Prefabs to spawn
    public int obstacleCount = 20;          // How many obstacles to spawn
    public Vector3 areaSize = new Vector3(50, 0, 50); // Spawn area size
    public LayerMask groundLayer;           // Layer to check for ground placement

    [Header("Spawn Options")]
    public float minScale = 1f;
    public float maxScale = 3f;

    private void Start()
    {
        SpawnObstacles();
    }

    private void SpawnObstacles()
    {
        if (obstaclePrefabs.Length == 0)
        {
            Debug.LogWarning("No obstacle prefabs assigned!");
            return;
        }

        for (int i = 0; i < obstacleCount; i++)
        {
            // Random position inside defined area
            Vector3 randomPos = transform.position + new Vector3(
                Random.Range(-areaSize.x / 2f, areaSize.x / 2f),
                0f,
                Random.Range(-areaSize.z / 2f, areaSize.z / 2f)
            );

            // Raycast down to place on the ground
            if (Physics.Raycast(randomPos + Vector3.up * 10f, Vector3.down, out RaycastHit hit, 50f, groundLayer))
            {
                randomPos.y = hit.point.y;

                // Pick a random prefab
                GameObject prefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];

                GameObject obstacle = Instantiate(prefab, randomPos, Quaternion.Euler(0f, Random.Range(0f, 360f), 0f));

                // Random scale
                float scale = Random.Range(minScale, maxScale);
                obstacle.transform.localScale = new Vector3(scale, scale, scale);

                // Make sure obstacle is on the obstacle layer (optional)
                // obstacle.layer = LayerMask.NameToLayer("Obstacle");
            }
        }
    }
}
