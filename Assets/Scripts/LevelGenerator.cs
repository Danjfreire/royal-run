using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    [SerializeField] private GameObject levelChunkPrefab;
    [SerializeField] private Transform levelChunkParent;
    [SerializeField] private int chunkAmount;
    [SerializeField] private float chunkLength;
    [SerializeField] private float chunkMoveSpeed;

    private List<GameObject> levelChunks = new List<GameObject>();

    private void Start()
    {
        GenerateLevelChunks();
    }

    private void Update()
    {
        MoveChunks();
    }

    private void GenerateLevelChunks()
    {
        for (int i = 0; i < chunkAmount; i++)
        {
            SpawnChunk();
        }
    }

    private void MoveChunks()
    {
        float zOffset = Time.deltaTime * chunkMoveSpeed;
        for (int i = 0; i < levelChunks.Count; i++)
        {
            GameObject chunk = levelChunks[i];
            chunk.transform.Translate(-transform.forward * zOffset);

            // if chunk gets out of view, remove it and spawn a new one as far as possible
            if (chunk.transform.position.z <= Camera.main.transform.position.z - chunkLength)
            {
                levelChunks.Remove(chunk);
                Destroy(chunk);
                SpawnChunk();
            }
        }
    }

    private void SpawnChunk()
    {
        float spawnPositionZ;

        if (levelChunks.Count == 0)
        {
            // if there are no level chunks yet, spawn a new one at the parent origin
            spawnPositionZ = levelChunkParent.transform.position.z;
        }
        else
        {
            // otherwise, get the last chunk and spawn next to it
            spawnPositionZ = levelChunks[levelChunks.Count - 1].transform.position.z + chunkLength;
        }

        Vector3 position = new Vector3(transform.position.x, transform.position.y, spawnPositionZ);
        GameObject levelChunk = Instantiate(levelChunkPrefab, position, Quaternion.identity, levelChunkParent);
        levelChunks.Add(levelChunk);
    }
}
