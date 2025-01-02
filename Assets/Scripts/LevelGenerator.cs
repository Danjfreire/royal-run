using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    [SerializeField] private GameObject levelChunkPrefab;
    [SerializeField] private Transform levelChunkParent;
    [SerializeField] private int chunkAmount;
    [SerializeField] private float chunkLength;

    private void Start()
    {
        GenerateLevel();
    }

    private void GenerateLevel()
    {

        for (int i = 0; i < chunkAmount; i++)
        {
            float zOffset = i * chunkLength;
            Vector3 position = new Vector3(transform.position.x, transform.position.y, transform.position.z + zOffset);
            Instantiate(levelChunkPrefab, position, Quaternion.identity, levelChunkParent);
        }
    }
}
