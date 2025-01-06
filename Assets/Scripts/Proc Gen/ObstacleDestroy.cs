using UnityEngine;

public class ObstacleDestroy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Destroying " + other.gameObject.name);
        Destroy(other.gameObject);
    }
}
