using System.Collections;
using UnityEngine;

public class GrabbableSpawner : MonoBehaviour
{
    // Prefab to spawn
    public GameObject prefab;
    public GameObject prefab2;

    // Number of objects to spawn
    public int numberOfObjects = 10;

    // The boundaries for random spawning positions
    public Vector3 spawnAreaMin = new Vector3(-10, 0, -10);
    public Vector3 spawnAreaMax = new Vector3(1000, 1000, 10);

    // Delay between spawns
    public float spawnInterval = 2f;

    void Start()
    {
        // Start the coroutine to spawn objects at intervals
        StartCoroutine(SpawnObjects());
    }

    // Coroutine that spawns objects at random positions
    IEnumerator SpawnObjects()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            // Generate a random position within the spawn area
            Vector3 randomPosition = new Vector3(
                Random.Range(spawnAreaMin.x, spawnAreaMax.x),
                Random.Range(spawnAreaMin.y, spawnAreaMax.y),
                Random.Range(spawnAreaMin.z, spawnAreaMax.z)
            );
            Vector3 randomPosition2 = new Vector3(
                Random.Range(spawnAreaMin.x, spawnAreaMax.x),
                Random.Range(spawnAreaMin.y, spawnAreaMax.y),
                Random.Range(spawnAreaMin.z, spawnAreaMax.z)
            );

            // Instantiate the prefab at the random position
            Instantiate(prefab, randomPosition, Quaternion.identity);
            Instantiate(prefab2, randomPosition2, Quaternion.identity);
            // Wait for the next spawn
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    // Optional: Draw the spawn area in the Scene view for easier debugging
    void OnDrawGizmosSelected()
    {
        // Draw a wireframe cube to visualize the spawn area
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube((spawnAreaMin + spawnAreaMax) / 2, spawnAreaMax - spawnAreaMin);
    }
}