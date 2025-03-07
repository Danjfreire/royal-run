using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public static LevelGenerator Instance { get; private set; }

    [Header("References")]
    [SerializeField] private CameraController cameraController;
    [SerializeField] private GameObject[] levelChunkPrefabs;
    [SerializeField] private GameObject checkpointPrefab;
    [SerializeField] private Transform levelChunkParent;

    [Header("Level Settings")]
    [SerializeField] private int checkpointDistance;
    [SerializeField] private int chunkAmount;
    [SerializeField] private float chunkLength;
    [SerializeField] private float chunkMoveSpeed;
    [SerializeField] private float minChunkMoveSpeed = 4f;
    [SerializeField] private float maxChunkMoveSpeed = 20f;
    [SerializeField] private float maxGravityZ = -22f;
    [SerializeField] private float minGravityZ = -2f;

    private List<GameObject> levelChunks = new List<GameObject>();
    private int spawnedChunks = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        GenerateLevelChunks();
    }

    private void Update()
    {
        MoveChunks();
    }

    public void AddChunkMoveSpeed(float increase)
    {
        float newMoveSpeed = Mathf.Clamp(chunkMoveSpeed + increase, minChunkMoveSpeed, maxChunkMoveSpeed);

        if (newMoveSpeed == chunkMoveSpeed) return;

        chunkMoveSpeed = newMoveSpeed;

        chunkMoveSpeed = Mathf.Clamp(chunkMoveSpeed, minChunkMoveSpeed, maxChunkMoveSpeed);
        float gravityZ = Mathf.Clamp(Physics.gravity.z - increase, maxGravityZ, minGravityZ);

        Physics.gravity = new Vector3(Physics.gravity.x, Physics.gravity.y, gravityZ);
        cameraController.ChangeCameraFOV(increase);
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
        GameObject levelChunk = Instantiate(GetChunkToSpawn(), position, Quaternion.identity, levelChunkParent);
        levelChunks.Add(levelChunk);
        spawnedChunks++;
    }

    private GameObject GetChunkToSpawn()
    {
        GameObject chunkToSpawn;

        if (spawnedChunks % checkpointDistance == 0 && spawnedChunks != 0)
        {
            chunkToSpawn = checkpointPrefab;
        }
        else
        {
            chunkToSpawn = levelChunkPrefabs[Random.Range(0, levelChunkPrefabs.Length)];
        }

        return chunkToSpawn;
    }
}
