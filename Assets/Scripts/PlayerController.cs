using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float xBound;
    [SerializeField] private float zBound;

    private Vector2 movement;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    public void Move(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }

    private void HandleMovement()
    {
        float speed = Time.fixedDeltaTime * moveSpeed;

        Vector3 moveDirection = new Vector3(movement.x, 0f, movement.y);
        Vector3 targetPosition = rb.position + moveDirection * speed;

        targetPosition.x = Mathf.Clamp(targetPosition.x, -xBound, xBound);
        targetPosition.z = Mathf.Clamp(targetPosition.z, -zBound, zBound);

        rb.MovePosition(targetPosition);
    }

}
