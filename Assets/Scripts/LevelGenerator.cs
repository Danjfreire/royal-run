using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    [SerializeField] private GameObject levelChunkPrefab;
    [SerializeField] private Transform levelChunkParent;
    [SerializeField] private int chunkAmount;
    [SerializeField] private float chunkLength;
    [SerializeField] private float chunkMoveSpeed;

    private GameObject[] levelChunks;

    private void Awake()
    {
        levelChunks = new GameObject[chunkAmount];
    }

    private void Start()
    {
        GenerateLevel();
    }

    private void Update()
    {
        MoveChunks();
    }

    private void GenerateLevel()
    {
        for (int i = 0; i < chunkAmount; i++)
        {
            float zOffset = i * chunkLength;
            Vector3 position = new Vector3(transform.position.x, transform.position.y, transform.position.z + zOffset);
            GameObject levelChunk = Instantiate(levelChunkPrefab, position, Quaternion.identity, levelChunkParent);
            levelChunks[i] = levelChunk;
        }
    }

    private void MoveChunks()
    {
        float zOffset = Time.deltaTime * chunkMoveSpeed;
        for (int i = 0; i < levelChunks.Length; i++)
        {
            levelChunks[i].transform.Translate(-transform.forward * zOffset);
        }
    }
}
