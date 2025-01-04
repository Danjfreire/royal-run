using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField] private GameObject fencePrefab;
    [SerializeField] private float[] lanePositions = { -2.5f, 0f, 2.5f };

    private void Start()
    {
        int laneIndex = Random.Range(0, lanePositions.Length);
        Vector3 spawnPosition = new Vector3(lanePositions[laneIndex], transform.position.y, transform.position.z);
        Instantiate(fencePrefab, spawnPosition, Quaternion.identity, this.transform);
    }
}
