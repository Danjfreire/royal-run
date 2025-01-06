using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Collided with:" + other.gameObject.name);
    }

}
