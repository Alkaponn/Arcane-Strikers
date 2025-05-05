using UnityEngine;
using UnityEngine.InputSystem;

public class MainCharacterMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Move();
    }

    void OnMove(InputValue value) {
        moveInput = value.Get<Vector2>();
    }

    void Move() {
        Vector2 newVelocityVector = movementSpeed * moveInput;
        rb.linearVelocity = newVelocityVector;
    }
}
