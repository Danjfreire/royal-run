using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private float increaseTime = 5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>() != null)
        {
            GameManager.Instance.IncreaseTime(increaseTime);
        }
    }
}
