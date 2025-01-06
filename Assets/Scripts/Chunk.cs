using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField] private GameObject fencePrefab;
    [SerializeField] private GameObject applePrefab;
    [SerializeField] private GameObject coinPrefab;

    [SerializeField] private float appleSpawnChance = 0.3f;
    [SerializeField] private float coinSpawnChance = 0.5f;

    [SerializeField] private float[] lanePositions = { -2.5f, 0f, 2.5f };

    private List<int> availableLanes = new List<int> { 0, 1, 2 };

    private void Start()
    {
        SpawnFences();
        SpawnApple();
        SpawnCoins();
    }

    private void SpawnFences()
    {
        int fencesToSpawn = Random.Range(0, availableLanes.Count);

        for (int i = 0; i < fencesToSpawn; i++)
        {
            if (availableLanes.Count <= 0) break;

            int lane = SelectLane();
            Vector3 spawnPosition = new Vector3(lanePositions[lane], transform.position.y, transform.position.z);
            Instantiate(fencePrefab, spawnPosition, Quaternion.identity, this.transform);
        }
    }

    private void SpawnApple()
    {
        if (availableLanes.Count <= 0) return;
        if (Random.value > appleSpawnChance) return;

        int lane = SelectLane();
        Vector3 spawnPosition = new Vector3(lanePositions[lane], transform.position.y, transform.position.z);
        Instantiate(applePrefab, spawnPosition, Quaternion.identity, this.transform);
    }

    private void SpawnCoins()
    {
        if (availableLanes.Count <= 0) return;
        if (Random.value > coinSpawnChance) return;

        int lane = SelectLane();
        int maxExclusiveCoins = 6;
        int coinsToSpawn = Random.Range(1, maxExclusiveCoins); // generate up to 5 coins
        float initialZspawnPos = -4f; // start spawning at the bottom of the block
        float spawnZoffset = 2f;

        for (int i = 0; i < coinsToSpawn; i++)
        {
            float zPosition = transform.position.z + initialZspawnPos + (spawnZoffset * i);
            Vector3 spawnPosition = new Vector3(lanePositions[lane], transform.position.y, zPosition);
            Instantiate(coinPrefab, spawnPosition, Quaternion.identity, this.transform);
        }
    }

    private int SelectLane()
    {
        int laneIndex = Random.Range(0, availableLanes.Count);
        int lane = availableLanes[laneIndex];
        availableLanes.RemoveAt(laneIndex);

        return lane;
    }
}
