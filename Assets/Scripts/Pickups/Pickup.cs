using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 100f;

    private void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>() != null)
        {
            OnPickUp();
            Destroy(gameObject);
        }
    }

    protected abstract void OnPickUp();
}
