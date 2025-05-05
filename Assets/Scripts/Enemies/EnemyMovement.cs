using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed;

    private Transform playerTransform;
    private Rigidbody2D rb;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        FollowPlayer();
    }

    void FollowPlayer() {
        Vector2 velocityDirection = playerTransform.position - transform.position;
        Vector2 velocity = movementSpeed * velocityDirection;
        rb.linearVelocity = velocity;
    }
}
