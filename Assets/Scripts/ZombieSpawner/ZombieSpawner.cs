using System.Collections;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    private const int ZOMBIE_SPAWN_INTERVAL = 3;

    [SerializeField] private Vector3[] spawnPositions;
    [SerializeField] private Zombie zombiePrefab;

    private void Start()
    {
        StartCoroutine(SpawnZombieCoroutine());
    }

    private IEnumerator SpawnZombieCoroutine()
    {
        int i = 0;

        while (i == 0)
        {
            yield return new WaitForSeconds(ZOMBIE_SPAWN_INTERVAL);

            Vector3 randomSpawnPosition = spawnPositions[Random.Range(0, spawnPositions.Length)];
            Instantiate(zombiePrefab, randomSpawnPosition, Quaternion.identity);
            i++;
        }
    }
}
