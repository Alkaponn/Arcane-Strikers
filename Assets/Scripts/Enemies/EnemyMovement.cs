using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    [SerializeField] float randomMovementSpeed;
    [SerializeField] float randomMovementCooldown;
    [SerializeField] float outOfEnemyRangeCooldown;
    [SerializeField] float stepBackRangeCooldown;

    private Rigidbody2D rb;
    private Transform playerTransform;
    private CapsuleCollider2D playerEnemyRange;
    private CircleCollider2D playerStepBackRange;
    private Vector2 randomMovementDirection;
    private float randomMovementTimer;
    private float outOfEnemyRangeTimer;
    private float stepBackRangeTimer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        playerEnemyRange = playerTransform.Find("EnemyRange").GetComponent<CapsuleCollider2D>();
        playerStepBackRange = playerTransform.Find("StepBackRange").GetComponent<CircleCollider2D>();

        MoveRandomly();
        RandomizeMovementDirection();
        randomMovementTimer = 0f;
        outOfEnemyRangeTimer = 0f;
        stepBackRangeTimer = 0f;
    }

    void Update()
    {
        Move();
    }

    void Move() {
        stepBackRangeTimer += Time.deltaTime;

        if (IsInPlayerStepBackRange()) {
            if (stepBackRangeTimer >= stepBackRangeCooldown) {
                stepBackRangeTimer = 0f;
                rb.linearVelocity = -rb.linearVelocity;
            }
        }
        else if (IsInPlayerEnemyRange()) {
            outOfEnemyRangeTimer = 0f;

            if (randomMovementTimer >= randomMovementCooldown) {
                randomMovementTimer = 0f;
                MoveRandomly();
            }
            else {
                randomMovementTimer += Time.deltaTime;
            }
        }
        else {
            if (outOfEnemyRangeTimer >= outOfEnemyRangeCooldown) {
                outOfEnemyRangeTimer = 0f;
                FollowPlayer();
            }
            else {
                outOfEnemyRangeTimer += Time.deltaTime;
            }
        }
    }

    bool IsInPlayerEnemyRange() {
        return playerEnemyRange.OverlapPoint(transform.position);
    }

    bool IsInPlayerStepBackRange() {
        float playerStepBackRangeRadius = playerStepBackRange.radius;
        float distance = GetDistanceBetweenPlayer().magnitude;

        return distance < playerStepBackRangeRadius;
    }

    void MoveRandomly() {
        RandomizeMovementDirection();
        rb.linearVelocity = randomMovementSpeed * randomMovementDirection;
    }

    void RandomizeMovementDirection() {
        float angle = Random.Range(0f, 360f);
        randomMovementDirection = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)).normalized;
    }

    void FollowPlayer() {
        Vector2 distanceVector = playerTransform.position - transform.position;
        Vector2 velocity = movementSpeed * distanceVector.normalized;
        rb.linearVelocity = velocity;
    }

    Vector2 GetDistanceBetweenPlayer() {
        return playerTransform.position - transform.position;
    }
}
