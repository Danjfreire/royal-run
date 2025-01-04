using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField] private GameObject fencePrefab;
    [SerializeField] private float[] lanePositions = { -2.5f, 0f, 2.5f };

    private void Start()
    {
        SpawnFences();
    }

    private void SpawnFences()
    {
        List<int> availableLanes = new List<int> { 0, 1, 2 };
        int fencesToSpawn = Random.Range(0, availableLanes.Count);

        for (int i = 0; i < fencesToSpawn; i++)
        {
            if (availableLanes.Count == 0) break;

            int laneIndex = Random.Range(0, availableLanes.Count);
            Vector3 spawnPosition = new Vector3(lanePositions[laneIndex], transform.position.y, transform.position.z);
            Instantiate(fencePrefab, spawnPosition, Quaternion.identity, this.transform);
            availableLanes.RemoveAt(laneIndex);
        }

    }
}
